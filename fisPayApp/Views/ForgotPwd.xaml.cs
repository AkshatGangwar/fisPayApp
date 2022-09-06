using fisPayApp.Models;
using fisPayApp.ViewModels;
using fisPayApp.Views.Registration;
using fisPayApp.Views.Updates;
using CommunityToolkit.Mvvm.ComponentModel;

namespace fisPayApp.Views;
public partial class ForgotPwd : ContentPage
{
    public ForgotPwd(ForgotPwdVM forgotPwdVM)
	{
		InitializeComponent();
		BindingContext = forgotPwdVM;
        Routing.RegisterRoute(nameof(UpdatePwdOTP), typeof(UpdatePwdOTP));
    }
}