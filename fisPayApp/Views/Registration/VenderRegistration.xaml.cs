using fisPayApp.ViewModels;

namespace fisPayApp.Views.Registration;

public partial class VenderRegistration : ContentPage
{
	public VenderRegistration()
	{
		InitializeComponent();
        var vendorRegisterVM = new VendorRegisterVM();
        BindingContext = vendorRegisterVM;
        Routing.RegisterRoute(nameof(VendorStoreAddress), typeof(VendorStoreAddress));
    }
}