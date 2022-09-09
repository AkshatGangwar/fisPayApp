
using fisPayApp.ViewModels;

namespace fisPayApp.Views;

public partial class NewPage1 : ContentPage
{
    
    public NewPage1()
    {
        var transactionsVM = new TransactionsVM();
        InitializeComponent();
        BindingContext = transactionsVM;
        transactionsVM.GetTxn();
    }  
}