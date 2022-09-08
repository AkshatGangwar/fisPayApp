using System.Security.Cryptography;

namespace fisPayApp.Views;

public partial class NewPage1 : ContentPage
{
    string lat = (27.189).ToString();
    string lon = (78.018).ToString();

    public string GeocodeAddress;

    public NewPage1()
    {
        InitializeComponent();
        //String cityName = 

        datas();
        GetGeocodeReverseData();
        ECDiff();
    }
    public async void datas()
    {
        try
        {
            double.TryParse(lat, out var lt);
            double.TryParse(lon, out var ln);

            var placemarks = await Geocoding.GetPlacemarksAsync(lt, ln);
            var placemark = placemarks?.FirstOrDefault();
            if (placemark == null)
            {
                GeocodeAddress = "Unable to detect placemarks.";
            }
            else
            {
                GeocodeAddress =
                    $"{nameof(placemark.AdminArea)}: {placemark.AdminArea}\n" +
                    $"{nameof(placemark.CountryCode)}: {placemark.CountryCode}\n" +
                    $"{nameof(placemark.CountryName)}: {placemark.CountryName}\n" +
                    $"{nameof(placemark.FeatureName)}: {placemark.FeatureName}\n" +
                    $"{nameof(placemark.Locality)}: {placemark.Locality}\n" +
                    $"{nameof(placemark.PostalCode)}: {placemark.PostalCode}\n" +
                    $"{nameof(placemark.SubAdminArea)}: {placemark.SubAdminArea}\n" +
                    $"{nameof(placemark.SubLocality)}: {placemark.SubLocality}\n" +
                    $"{nameof(placemark.SubThoroughfare)}: {placemark.SubThoroughfare}\n" +
                    $"{nameof(placemark.Thoroughfare)}: {placemark.Thoroughfare}\n";
            }
        }
        catch (Exception ex)
        {
            GeocodeAddress = $"Unable to detect placemarks: {ex.Message}";
        }
        DisplayAlert("msg1", GeocodeAddress, "ok");
    }
    private async void GetGeocodeReverseData(double latitude = 47.673988, double longitude = -122.121513)
    {
        try
        {
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

            Placemark placemark = placemarks?.FirstOrDefault();

            if (placemark != null)
            {
                GeocodeAddress =
                   $"AdminArea:       {placemark.AdminArea}\n" +
                    $"CountryCode:     {placemark.CountryCode}\n" +
                    $"CountryName:     {placemark.CountryName}\n" +
                    $"FeatureName:     {placemark.FeatureName}\n" +
                    $"Locality:        {placemark.Locality}\n" +
                    $"PostalCode:      {placemark.PostalCode}\n" +
                    $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                    $"SubLocality:     {placemark.SubLocality}\n" +
                    $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                    $"Thoroughfare:    {placemark.Thoroughfare}\n";

            }
        }
        catch (Exception ex)
        {
            GeocodeAddress = $"Unable to detect placemarks: {ex.Message}";
        }
        DisplayAlert("msg2", GeocodeAddress, "ok");
    }
    private async void ECDiff()
    {
        try
        {
            string address = "Microsoft Building 25 Redmond WA USA";
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if (location != null)
                lbl.Text = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        }
        catch (Exception ex)
        {
            lbl.Text = ex.Message;
        }
    }
}