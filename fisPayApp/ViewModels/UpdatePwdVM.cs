using fisPayApp.Models;
using fisPayApp.Services;
using fisPayApp.Views;
using fisPayApp.Views.Updates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(UserId), "userId")]
    public partial class UpdatePwdVM : BaseVM
    {
        private string userId;
        public string UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string confPassword;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        public async void Update()
        {
            if (!string.IsNullOrWhiteSpace(ConfPassword) && !string.IsNullOrWhiteSpace(Password))
            {
                if (ConfPassword== Password)
                {
                    Indicator = "True";
                    var response = await loginRepository.UpdatePwd(new UpdatePwdRequest
                    {
                        userID = UserId,
                        password = Password
                    });
                    if (response.resultCode.statusCode == "200")
                    {
                        Indicator = "False";
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Password Updated Successfully!", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                    }
                    else
                    {
                        Indicator = "False";
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Error", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                    }
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Password Didn't Match!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }  
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("");
                if (string.IsNullOrWhiteSpace(ConfPassword) && string.IsNullOrWhiteSpace(Password))
                {
                    toast = Toast.Make("Enter New Password and Confirm Password", ToastDuration.Short, 18);
                }
                else if (string.IsNullOrWhiteSpace(ConfPassword))
                {
                    toast = Toast.Make("Confirm Password Cann't be Empty", ToastDuration.Short, 18);
                }
                else
                {
                    toast = Toast.Make("New Password Cann't be Empty", ToastDuration.Short, 18);
                }

                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
