using fisPayApp.Models;
using System.Collections.ObjectModel;

namespace fisPayApp.ViewModels
{
    public partial class TransactionsVM: BaseVM
    {
        ObservableCollection<TxnList> transactions;
        public ObservableCollection<TxnList> Transactions
        {
            get
            {
                return transactions;
            }
            set
            {
                transactions = value;
                OnPropertyChanged();
            }
        }
    }
}
