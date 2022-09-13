using fisPayApp.ViewModels;
using MauiApp1;

namespace fisPayApp.Views.DashBoard;

public partial class VendorDashBoardPage : ContentPage
{
	public VendorDashBoardPage()
	{
		InitializeComponent();
        BindingContext = new VendorDashboardVM();
        Routing.RegisterRoute(nameof(PdfReports), typeof(PdfReports));
        Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
        Routing.RegisterRoute(nameof(RewardsPage), typeof(RewardsPage));
        Routing.RegisterRoute(nameof(TxnHistory), typeof(TxnHistory));
        Routing.RegisterRoute(nameof(StoreDetails), typeof(StoreDetails));
    }
}