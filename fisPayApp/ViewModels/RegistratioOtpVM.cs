using fisPayApp.Views.Registration;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    [QueryProperty(nameof(OTP), "otp")]
    public partial class RegistratioOtpVM : BaseVM
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
                string InputOTP =FirstDigit+SecondDigit+ThirdDigit+FourthDigit;
                if (RecievedOTP == InputOTP)
                {
                    await Shell.Current.GoToAsync($"{nameof(DetailsCapturePage)}?mobileNum={MobileNum}");
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Invalid OTP!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
        }
    }
}