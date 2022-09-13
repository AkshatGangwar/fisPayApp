using fisPayApp.ViewModels;
using fisPayApp.Views.Payments;

namespace MauiApp1;

public partial class SearchCustomer : ContentPage
{
	public SearchCustomer()
	{
		InitializeComponent();
		BindingContext =new SearchCustomerVM();
        Routing.RegisterRoute(nameof(MobilePay), typeof(MobilePay));
    }
}