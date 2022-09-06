using fisPayApp.ViewModels;

namespace MauiApp1;

public partial class TxnHistory : ContentPage
{
	public TxnHistory()
	{
		InitializeComponent();
        BindingContext = new  TransactionsVM();
    }
}