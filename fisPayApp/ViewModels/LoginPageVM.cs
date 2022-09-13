using fisPayApp.Models;
using fisPayApp.Services;
using fisPayApp.Views.Registration;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using fisPayApp.Interfaces;
using fisPayApp.Views;
using fisPayApp.Handlers;

namespace fisPayApp.ViewModels
{
    public partial class LoginPageVM : BaseVM
    {
        private string userMobile;
        public string UserMobile
        {
            get { return userMobile; }
            set
            {
                userMobile = value;
                Handlers.Settings.LastUsedLoginID = value;
            }
        }

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string signing = "False";
        readonly ILoginRepository loginRepository = new LoginService();

        [RelayCommand]
        public async void Login()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(UserMobile) && !string.IsNullOrWhiteSpace(Password))
                {
                    Signing = "True";
                    var response = await loginRepository.Login(new LoginRequest
                    {
                        mobile = UserMobile,
                        password = Password
                    });
                    if (response != null)
                    {
                        response.dataObject.data.mobile = UserMobile;
                        if (Preferences.ContainsKey(nameof(App.UserDetails)))
                        {
                            Preferences.Remove(nameof(App.UserDetails));
                        }
                        await SecureStorage.SetAsync(nameof(App.Token), response.dataObject.data.token);
                        string userDetailStr = JsonConvert.SerializeObject(response.dataObject.data);
                        Preferences.Set(nameof(App.UserDetails), userDetailStr);
                        App.UserDetails = response.dataObject.data;
                        App.Token = response.dataObject.data.token;
                        Signing = "False";
                        await AppConstant.AddFlyoutMenusDetails();
                    }
                    else
                    {
                        Signing = "False";
                        Validation.toastmsg("Invalid Credentials", "S", 18);
                    }
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    string msg="";
                    if (string.IsNullOrWhiteSpace(UserMobile) && string.IsNullOrWhiteSpace(Password))
                    {
                        msg = "Enter Mobile Number and Password to Signin";
                    }
                    else if (string.IsNullOrWhiteSpace(UserMobile))
                    {
                        msg = "Enter Mobile Number to Signin";
                    }
                    else
                    {
                        msg = "Enter Password to Signin";
                    }

                    Validation.toastmsg(msg, "S", 18);
                }
            }
            catch (Exception)
            {
                Validation.toastmsg("Error", "S", 18);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async void ForgotPwd()
        {
            await Shell.Current.GoToAsync($"{nameof(ForgotPwd)}?mobileNum={UserMobile}");
        }
        [RelayCommand]
        public async void RegisterPage()
        {
            await Shell.Current.GoToAsync(nameof(RegistrationPage));
        }
        [RelayCommand]
        public async void DevPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NewPage1)}");
        }
    }
}
