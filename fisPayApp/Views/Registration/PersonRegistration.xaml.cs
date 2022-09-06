using CommunityToolkit.Maui.Views;
using fisPayApp.ViewModels;
using fisPayApp.Views.PopUps;

namespace fisPayApp.Views.Registration;

public partial class PersonRegistration : ContentPage
{
	public PersonRegistration()
	{
		InitializeComponent();
        var personRegisterVM = new PersonRegisterVM();
        BindingContext = personRegisterVM;
    }
    private void btnClicked(object sender, EventArgs e)
    {
        var popUpData = new PasswordPolicy();
        this.ShowPopup(popUpData);
    }
}