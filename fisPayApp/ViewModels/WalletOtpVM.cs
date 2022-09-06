using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Handlers;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;
using MauiApp1;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(OTP), "otp")]
    public partial class WalletOtpVM : BaseVM
    {
        private string oTP;
        public string OTP
        {
            get => oTP;
            set
            {
                oTP = value;
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        private string firstDigit;
        [ObservableProperty]
        private string secondDigit;
        [ObservableProperty]
        private string thirdDigit;
        [ObservableProperty]
        private string fourthDigit;
        [ObservableProperty]
        private string lblResendText;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void Resend(string lblResendText)
        {
            if (LblResendText == "Resend")
            {
                Indicator = "True";
                await Task.Delay(1500);
                //var response = await loginRepository.RegistrationOtp(MobileNum);
                //OTP = response.dataObject.data.otp;
                var response = "1234";
                OTP = response;
                if (response != null)
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("OTP Sent Successfully!", ToastDuration.Short, 18);
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
                Indicator = "False";
            }
        }
        [RelayCommand]
        async void Verify()
        {
            if (!string.IsNullOrWhiteSpace(OTP))
            {
                string RecievedOTP = OTP;
                string InputOTP = FirstDigit + SecondDigit + ThirdDigit + FourthDigit;
                if (RecievedOTP == InputOTP)
                {
                    Indicator = "True";
                    var response = await loginRepository.SetWalletFlag(new WalletRequest
                    {
                        isActivate = true
                    });
                    if (response.resultCode.statusCode == "200")
                    {
                        Indicator = "False";
                        App.UserDetails.isWalletActivate = true;
                        await AppConstant.AddFlyoutMenusDetails();
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Success!", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
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
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Invalid OTP!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
        }
    }
}
