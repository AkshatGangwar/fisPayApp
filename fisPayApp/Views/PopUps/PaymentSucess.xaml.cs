using fisPayApp.Controls;
using fisPayApp.ViewModels;

namespace MauiApp1;

public partial class PaymentSucess : BasePopUp
{
	public PaymentSucess()
	{
		InitializeComponent();
		BindingContext = new PaymentSuccessVM();
    }
}