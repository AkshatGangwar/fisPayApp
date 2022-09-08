using CommunityToolkit.Maui.Views;
using fisPayApp.Models;
using fisPayApp.Views.Payments;

namespace MauiApp1;

public partial class StorePopup : Popup
{
    private readonly StoreList storeList;

    public StorePopup(StoreList item)
	{
        InitializeComponent();
        storeList = item;
    }

    private async void Pay(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(MobilePay)}?name={storeList.storeName}&userId={storeList.storeId}");
        Close();
    }

    private async void OpenMap(object sender, EventArgs e)
    {
        await Map.OpenAsync(double.Parse(storeList.latitude), double.Parse(storeList.longitude), new MapLaunchOptions
        {
            Name = storeList.storeName,
            NavigationMode = 0
        });
        Close();
    }
    async void OpenPlacemark(object sender, EventArgs e)
    {
        var placemark = new Placemark
        {
            Locality = storeList.city,
            AdminArea = storeList.state,
            CountryName = storeList.country,
            Thoroughfare = storeList.storeName+ " " + storeList.address+" "+ storeList.landmark,
            PostalCode = storeList.zipcode
        };
        await Map.OpenAsync(placemark, new MapLaunchOptions
        {
            Name = storeList.storeName,
            NavigationMode = 0
        });
    }
}