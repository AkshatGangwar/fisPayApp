using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;
using System.Collections.ObjectModel;

namespace fisPayApp.ViewModels
{
    public partial class TransactionsVM : BaseVM
    {
        ObservableCollection<TxnList> transactions;
        readonly IPdfCreate pdfCreate = new PdfService();
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
        [ObservableProperty]
        private string indicator = "False";
        [ObservableProperty]
        private string headerIndicator = "False";
        public async void GetTxn()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Indicator = "True";
                var response = await pdfCreate.getTXN();
                if (response != null)
                {
                    HeaderIndicator = "True";
                    Transactions = new ObservableCollection<TxnList>(response.dataObject.data);
                }
            }
            catch (Exception)
            {
                Indicator = "False";
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Error", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
            finally
            {
                IsBusy = false;
                Indicator = "False";
            }
        }
    }
}
