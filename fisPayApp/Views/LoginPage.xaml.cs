using fisPayApp.ViewModels;
using fisPayApp.Views.Registration;

namespace fisPayApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageVM loginPageVM)
	{
		InitializeComponent();
        BindingContext = loginPageVM;
        if (Handlers.Settings.SetRememberChk)
        {
            chkRememberMe.IsChecked = true;
            UserMobile.Text = Handlers.Settings.LastUsedLoginID;
        }
        Routing.RegisterRoute(nameof(RegistrationPage),typeof(RegistrationPage));
        Routing.RegisterRoute(nameof(ForgotPwd),typeof(ForgotPwd));
        Routing.RegisterRoute(nameof(NewPage1), typeof(NewPage1));
    }
    private void UpdateRemChkBoxVal(object sender, CheckedChangedEventArgs e)
    {
        Handlers.Settings.SetRememberChk = chkRememberMe.IsChecked;
    }

    private void onFocusOutEntry(object sender, FocusEventArgs e)
    {

    }

}