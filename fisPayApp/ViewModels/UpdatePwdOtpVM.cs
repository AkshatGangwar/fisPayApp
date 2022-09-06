using fisPayApp.Views.Registration;
using fisPayApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fisPayApp.Views.Updates;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    [QueryProperty(nameof(OTP), "otp")]
    [QueryProperty(nameof(UserId), "userId")]
    public partial class UpdatePwdOtpVM : BaseVM
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
        async void Resend()
        {
            if (LblResendText == "Resend")
            {
                Indicator = "True";
                var response = await loginRepository.UpdatePwdOtp(MobileNum);
                if (response != null)
                {
                    Indicator = "False";
                    OTP = response.dataObject.data.otp;
                    UserId = response.dataObject.data.userId;
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
                    await Shell.Current.GoToAsync($"{nameof(UpdatePwd)}?userId={UserId}");
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

