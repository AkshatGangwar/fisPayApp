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
    public partial class WalletVM: BaseVM
    {
        [ObservableProperty]
        private string pan;
        [ObservableProperty]
        private string amount;
        [ObservableProperty]
        private string comment;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void Activate()
        {
            if (!string.IsNullOrWhiteSpace(Pan))
            {
                Indicator = "True";
                var response = await loginRepository.ActivateWallet(new WalletRequest
                {
                    panNumber = Pan
                });
                if (response != null)
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("OTP Sent Successfully!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                    await Shell.Current.GoToAsync($"{nameof(WalletOtp)}?otp={response.dataObject.data.otp}");
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
                var toast = Toast.Make("Enter PAN Number to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
        [RelayCommand]
        async void Add()
        {
            if (!string.IsNullOrWhiteSpace(Amount))
            {
                Indicator = "True";
                var response = await loginRepository.AddWalletAmount(new AddWalletRequest
                {
                    amount = Amount,
                    comment= Comment
                });
                if (response.resultCode.statusCode == "200")
                {
                    Indicator = "False";
                    await AppConstant.AddFlyoutMenusDetails();
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Ammount Added Succesfully!", ToastDuration.Short, 18);
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
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Amount cannot be null or zero...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
