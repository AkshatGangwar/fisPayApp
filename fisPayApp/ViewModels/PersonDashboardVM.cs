using CommunityToolkit.Mvvm.Input;
using fisPayApp.Views.Payments;
using fisPayApp.Views.Person;
using MauiApp1;

namespace fisPayApp.ViewModels
{
    public partial class PersonDashboardVM: BaseVM
    {
        [RelayCommand]
        async void QRPay()
        {
            await Shell.Current.GoToAsync(nameof(QRScanner));
        }
        [RelayCommand]
        async void Mobile()
        {
            await Shell.Current.GoToAsync(nameof(SearchCustomer));
        }
        [RelayCommand]
        async void History()
        {
            await Shell.Current.GoToAsync(nameof(TxnHistory));
        }
        [RelayCommand]
        async void PDF()
        {
            await Shell.Current.GoToAsync(nameof(PdfReports));
        }
        [RelayCommand]
        async void Store()
        {
            await Shell.Current.GoToAsync(nameof(StoreLocator));
        }
        [RelayCommand]
        async void Wallet()
        {
            await Shell.Current.GoToAsync(nameof(WalletPage));
        }
        [RelayCommand]
        async void Refer()
        {
            await Shell.Current.GoToAsync(nameof(ReferNEarn));
        }
        [RelayCommand]
        async void Profile()
        {
            await Shell.Current.GoToAsync(nameof(PersonProfile));
        }
        [RelayCommand]
        async void Reward()
        {
            await Shell.Current.GoToAsync(nameof(RewardsPage));
        }
        [RelayCommand]
        async void Support()
        {
            await Shell.Current.GoToAsync(nameof(HelpPage));
        }
        [RelayCommand]
        async void Discount()
        {
            await Shell.Current.GoToAsync(nameof(DiscountPage));
        }
    }
}
