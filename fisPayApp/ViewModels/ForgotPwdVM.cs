using fisPayApp.Models;
using fisPayApp.Services;
using fisPayApp.Views;
using fisPayApp.Views.Registration;
using fisPayApp.Views.Updates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    public partial class ForgotPwdVM : BaseVM
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
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();

        [RelayCommand]
        async void UpdatePassword()
        {
            if (!string.IsNullOrWhiteSpace(MobileNum))
            {
                Indicator = "True";
                var response = await loginRepository.UpdatePwdOtp(MobileNum);
                if (response != null)
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("OTP Sent Successfully!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                    await Shell.Current.GoToAsync($"{nameof(UpdatePwdOTP)}?mobileNum={MobileNum}&otp={response.dataObject.data.otp}&userId={response.dataObject.data.userId}");
                }

                else
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("User Doesn't Exist with this Mobile Number!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Enter Mobile Number to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
