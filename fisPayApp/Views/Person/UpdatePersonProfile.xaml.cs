using fisPayApp.ViewModels;

namespace fisPayApp.Views.Person;

public partial class UpdatePersonProfile : ContentPage
{
	public UpdatePersonProfile(PersonProfileVM personProfileVM)
	{
		InitializeComponent();
        BindingContext = personProfileVM;
        personProfileVM.Name = App.UserDetails.name;
        personProfileVM.Email = App.UserDetails.emailId;
    }
}