using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using fisPayApp.Models;
using System.Collections.ObjectModel;

namespace fisPayApp.ViewModels
{
    public partial class StoreLocatorVM: BaseVM
    {
        ObservableCollection<StoreList> storeLists;
        public ObservableCollection<StoreList> StoreLists
        {
            get
            {
                return storeLists;
            }
            set
            {
                storeLists = value;
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        private string city;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        
        [RelayCommand]
        async void GetStoreByCity()
        {
            StoreLists = null;
            if (!string.IsNullOrWhiteSpace(City))
            {
                Indicator = "True";
                var response = await loginRepository.GetStoreList(City);
                if (response != null)
                {
                    List<StoreList> LT = response.dataObject.data;
                    StoreLists = new ObservableCollection<StoreList>(LT);
                    Indicator = "False";
                }

                else
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Error", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                Indicator = "False";
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Enter City to Search...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }

    }
}
