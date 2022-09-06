using fisPayApp.Views;
using fisPayApp.Views.Registration;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using fisPayApp.Interfaces;
using fisPayApp.Views.Updates;
using CommunityToolkit.Maui.Alerts;
using fisPayApp.Services;

namespace fisPayApp.ViewModels
{
    public partial class RegisterVM : BaseVM
    {
        [ObservableProperty]
        private string mobile;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void RequestOTP()
        {
            if (!string.IsNullOrWhiteSpace(Mobile))
            {
                Indicator = "True";
                //var response = await loginRepository.RegistrationOtp(Mobile);
                await Task.Delay(1500);
                var response = "1234";
                if (response != null)
                {
                    Indicator = "False";
                    //await Shell.Current.GoToAsync($"{nameof(RegistrationOTP)}?mobileNum={Mobile}&otp={response.dataObject.data.otp}");
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("OTP Sent Successfully!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                    await Shell.Current.GoToAsync($"{nameof(RegistrationOTP)}?mobileNum={Mobile}&otp={response}");
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
                var toast = Toast.Make("Enter Mobile Number to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
