using CommunityToolkit.Mvvm.Input;
using MauiApp1;

namespace fisPayApp.ViewModels
{
    public partial class VendorDashboardVM:BaseVM
    {
        
        [RelayCommand]
        async void AccountPage()
        {
            await Shell.Current.GoToAsync(nameof(AccountPage));
        }
        [RelayCommand]
        async void HistoryPage()
        {
            await Shell.Current.GoToAsync(nameof(TxnHistory));
        }
        [RelayCommand]
        async void PDFDownload()
        {
            await Shell.Current.GoToAsync(nameof(PdfReports));
        }
        [RelayCommand]
        async void Store()
        {
            await Shell.Current.GoToAsync(nameof(StoreDetails));
        }
        
        [RelayCommand]
        async void Reward()
        {
            await Shell.Current.GoToAsync(nameof(RewardsPage));
        }
    }
}
