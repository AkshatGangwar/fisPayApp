using CommunityToolkit.Maui.Views;
using fisPayApp.ViewModels;
using fisPayApp.Views.PopUps;

namespace fisPayApp.Views;

public partial class UpdatePwd : ContentPage
{
	public UpdatePwd()
	{
		InitializeComponent();
		var updatePwdVM = new UpdatePwdVM();
		BindingContext = updatePwdVM;
	}

	private void btnClicked(object sender, EventArgs e)
	{
        var popUpData = new PasswordPolicy();
        this.ShowPopup(popUpData);
    }
}