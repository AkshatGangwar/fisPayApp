using CommunityToolkit.Maui.Views;
using fisPayApp.Models;
using fisPayApp.Views.Payments;

namespace MauiApp1;

public partial class StorePopup : Popup
{
    private string storeName;
    private string storeID;
    private string latitude;
    private string longitude;

    public StorePopup(StoreList item)
	{
        InitializeComponent();
        storeID = item.storeId;
        storeName = item.storeName;
        latitude = item.latitude;
        longitude = item.longitude;
    }

    private async void Pay(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(MobilePay)}?name={storeName}&userId={storeID}");
        Close();
    }

    private async void OpenMap(object sender, EventArgs e)
    {
        await Map.OpenAsync(double.Parse(latitude), double.Parse(longitude), new MapLaunchOptions
        {
            Name = storeName,
            NavigationMode = 0
        });
        Close();
    }
}