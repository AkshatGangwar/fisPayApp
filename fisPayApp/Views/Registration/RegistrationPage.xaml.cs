using fisPayApp.ViewModels;

namespace fisPayApp.Views.Registration;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
        BindingContext = new RegisterVM();
        Routing.RegisterRoute(nameof(DetailsCapturePage), typeof(DetailsCapturePage));
        Routing.RegisterRoute(nameof(RegistrationOTP), typeof(RegistrationOTP));
    }
}