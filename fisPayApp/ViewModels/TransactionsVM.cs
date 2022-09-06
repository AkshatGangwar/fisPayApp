using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.ViewModels
{
    public partial class TransactionsVM: BaseVM
    {
        ObservableCollection<StoreList> transactions;
        public ObservableCollection<StoreList> Transactions
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
