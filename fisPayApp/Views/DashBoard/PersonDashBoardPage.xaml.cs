using fisPayApp.ViewModels;
using fisPayApp;
using fisPayApp.Views.Payments;
using fisPayApp.Views.Person;

namespace MauiApp1;

public partial class PersonDashBoardPage : ContentPage
{
	public PersonDashBoardPage()
	{
		InitializeComponent();
        BindingContext = new PersonDashboardVM();
        Routing.RegisterRoute(nameof(QRScanner), typeof(QRScanner));
        Routing.RegisterRoute(nameof(PdfReports), typeof(PdfReports));
        Routing.RegisterRoute(nameof(MobilePay), typeof(MobilePay));
        Routing.RegisterRoute(nameof(ReferNEarn), typeof(ReferNEarn));
        Routing.RegisterRoute(nameof(RewardsPage), typeof(RewardsPage));
        Routing.RegisterRoute(nameof(TxnHistory), typeof(TxnHistory));
        Routing.RegisterRoute(nameof(WalletPage), typeof(WalletPage));
        Routing.RegisterRoute(nameof(PersonProfile), typeof(PersonProfile));
        Routing.RegisterRoute(nameof(HelpPage), typeof(HelpPage));
        Routing.RegisterRoute(nameof(StoreLocator), typeof(StoreLocator));
        Routing.RegisterRoute(nameof(DiscountPage), typeof(DiscountPage));
    }
}