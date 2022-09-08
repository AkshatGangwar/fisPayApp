using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using fisPayApp.Models;
using System.Collections.ObjectModel;
using fisPayApp.Views.Payments;

namespace fisPayApp.ViewModels
{
    public partial class StoreLocatorVM: BaseVM
    {
        ObservableCollection<StoreList> storeLists;
        CancellationTokenSource cts;
        string notAvailable = "not available";
        [ObservableProperty]
        private string currentLocation;
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
                CurrentLocation = FormatLocation(location);
            }
            catch (Exception ex)
            {
                CurrentLocation = FormatLocation(null, ex);
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
        string FormatLocation(Location location, Exception ex = null)
        {
            if (location == null)
            {
                return $"Unable to detect location. Exception: {ex?.Message ?? string.Empty}";
            }

            return
                $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n" +
                $"HorizontalAccuracy: {location.Accuracy}\n" +
                $"Altitude: {(location.Altitude.HasValue ? location.Altitude.Value.ToString() : notAvailable)}\n" +
                $"AltitudeRefSys: {location.AltitudeReferenceSystem.ToString()}\n" +
                $"VerticalAccuracy: {(location.VerticalAccuracy.HasValue ? location.VerticalAccuracy.Value.ToString() : notAvailable)}\n" +
                $"Heading: {(location.Course.HasValue ? location.Course.Value.ToString() : notAvailable)}\n" +
                $"Speed: {(location.Speed.HasValue ? location.Speed.Value.ToString() : notAvailable)}\n" +
                $"Date (UTC): {location.Timestamp:d}\n" +
                $"Time (UTC): {location.Timestamp:T}\n" +
                $"Moking Provider: {location.IsFromMockProvider}";
        }
    }
}
