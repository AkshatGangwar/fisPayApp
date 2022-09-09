using fisPayApp.ViewModels;

namespace fisPayApp.Views.Person;

public partial class UpdatePersonProfile : ContentPage
{
	public UpdatePersonProfile()
	{
        InitializeComponent();
        BindingContext = new PersonProfileVM();
    }
}