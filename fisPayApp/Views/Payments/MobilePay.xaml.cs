using fisPayApp.ViewModels;
using MauiApp1;

namespace fisPayApp.Views.Payments;

public partial class MobilePay : ContentPage
{
	public MobilePay()
	{
		InitializeComponent();
		BindingContext = new MobilePayVM();
        Routing.RegisterRoute(nameof(PaymentSucess), typeof(PaymentSucess));
    }
}