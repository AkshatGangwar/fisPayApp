using fisPayApp;
using fisPayApp.ViewModels;

namespace MauiApp1;

public partial class WalletPage : ContentPage
{
	public WalletPage()
	{
		InitializeComponent();
		BindingContext = new WalletVM();
        if (App.UserDetails.isWalletActivate)
        {
            ActWalletStack.IsVisible = false;
        }
        else
        {
            ActWalletStack.IsVisible = true;
        }
        Routing.RegisterRoute(nameof(WalletOtp), typeof(WalletOtp));
    }
}