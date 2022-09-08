using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using fisPayApp.Models;
using System.Collections.ObjectModel;
using fisPayApp.Views.Payments;
using Microsoft.Maui.Controls;

namespace fisPayApp.ViewModels
{
    public partial class StoreLocatorVM: BaseVM
    {
        ObservableCollection<StoreList> storeLists;
        CancellationTokenSource cts;
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
        private string storeName;
        [ObservableProperty]
        private string storeID;
        [ObservableProperty]
        private string geoCode;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        
        [RelayCommand]
        async void GetStoreByCity()
        {
            StoreLists = null;
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
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
            catch (Exception)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Error", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
            IsBusy = false;
        }
        [RelayCommand]
        async void GetStoreByGps()
        {
            StoreLists = null;
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                var request = new GeolocationRequest(0);
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                try
                {
                    IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    Placemark placemark = placemarks?.FirstOrDefault();
                    if (placemark == null)
                    {
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Error", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                    }
                    else
                    {
                        City = placemark.Locality;
                        GetStoreByCity();
                    }
                }
                catch (Exception)
                {
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Error", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            catch (Exception)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Error", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
            finally
            {
                cts.Dispose();
                cts = null;
            }
            IsBusy = false;
        }
        [RelayCommand]
        async void Pay()
        {
            await Shell.Current.GoToAsync($"{nameof(MobilePay)}?name={StoreName}&userId={StoreID}");
        }
    }
}
