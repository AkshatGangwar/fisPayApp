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
    public partial class WalletVM : BaseVM
    {
        [ObservableProperty]
        private string pan;
        [ObservableProperty]
        private string amount;
        [ObservableProperty]
        private string comment;
        [ObservableProperty]
        private string bal= App.UserDetails.walletBal;
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
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(Amount))
                {
                    Indicator = "True";
                    var response = await loginRepository.AddWalletAmount(new AddWalletRequest
                    {
                        userId = App.UserDetails.userId,
                        amount = Amount,
                        comment = Comment
                    });
                    if (response!= null)
                    {
                        Indicator = "False";
                        Bal = response.dataObject.data.totalBalance;
                        App.UserDetails.walletBal = Bal;
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
            catch (Exception)
            {
                Indicator = "False";
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Error", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
