using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using fisPayApp.Models;
using System.Collections.ObjectModel;
using fisPayApp.Handlers;

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
                        List<StoreList> Lt= (response.dataObject.data).OrderBy(x => x.distan).ToList();
                        StoreLists = new ObservableCollection<StoreList>(Lt);
                        Indicator = "False";
                    }

                    else
                    {
                        Indicator = "False";
                        Validation.toastmsg("Error", "S", 18);
                    }
                }
                else
                {
                    Indicator = "False";
                    Validation.toastmsg("Enter City to Search...", "S", 18);
                }
            }
            catch (Exception)
            {
                Indicator = "False";
                Validation.toastmsg("Error", "S", 18);
            }
            finally
            {
                IsBusy = false;
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
                try
                {
                    IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    Placemark placemark = placemarks?.FirstOrDefault();
                    if (placemark == null)
                    {
                        Validation.toastmsg("Error", "S", 18);
                    }
                    else
                    {
                        IsBusy = false;
                        City = placemark.Locality;
                        GetStoreByCity();
                    }
                }
                catch (Exception)
                {
                    Validation.toastmsg("Error","S",18);
                }
            }
            catch (Exception)
            {
                Validation.toastmsg("Error", "S", 18);
            }
            finally
            {
                cts.Dispose();
                cts = null;
            }
            IsBusy = false;
        }
    }
}
