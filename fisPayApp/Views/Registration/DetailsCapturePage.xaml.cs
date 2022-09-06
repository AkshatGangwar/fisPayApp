using fisPayApp.ViewModels;

namespace fisPayApp.Views.Registration;

public partial class DetailsCapturePage : ContentPage
{
	public DetailsCapturePage()
	{
		InitializeComponent();
		var detailsCaptureVM = new DetailsCaptureVM();
		BindingContext = detailsCaptureVM;
        Routing.RegisterRoute(nameof(PersonRegistration), typeof(PersonRegistration));
        Routing.RegisterRoute(nameof(VenderRegistration), typeof(VenderRegistration));
    }
}