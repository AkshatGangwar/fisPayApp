using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;
using fisPayApp.Handlers;
using fisPayApp.Views.Updates;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    public partial class PersonRegisterVM:BaseVM
    {
        private string mobileNum;
        public string MobileNum
        {
            get => mobileNum;
            set
            {
                mobileNum = value;
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void SignUp()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                if (Validation.ValidatePassword(Password))
                {
                    Indicator = "True";
                    var response = await loginRepository.RegisterPerson(new PersonProfileData
                    {
                        name = Name,
                        mobile = MobileNum,
                        password = Password,
                        email = Email,
                        userType = "1",
                        isActive = "true"
                    });
                    if (response.resultCode.statusCode == "200")
                    {
                        Indicator = "False";
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Success!", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    }

                    else
                    {
                        Indicator = "False";
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Error!", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                    }
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Invalid Password!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Enter Name/Email/Password to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
        [RelayCommand]
        async void LoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
