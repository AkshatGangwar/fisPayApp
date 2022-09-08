using fisPayApp.ViewModels;

namespace MauiApp1;

public partial class TxnHistory : ContentPage
{
	public TxnHistory()
	{
		var transactionsVM= new TransactionsVM();
        InitializeComponent();
        BindingContext = transactionsVM;
        transactionsVM.GetTxn();
    }
}