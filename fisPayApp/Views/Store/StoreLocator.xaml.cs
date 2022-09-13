using CommunityToolkit.Maui.Views;
using fisPayApp.Handlers;
using fisPayApp.Models;
using fisPayApp.ViewModels;
using fisPayApp.Views.Payments;
using MauiApp1;
using Newtonsoft.Json;

namespace fisPayApp;

public partial class StoreLocator : ContentPage
{
    private readonly List<string> cityStr;
    
    public StoreLocator()
	{
		InitializeComponent();
        var storeLocatorVM = new StoreLocatorVM();
        BindingContext= storeLocatorVM;
        List<CityList> CL = JsonConvert.DeserializeObject<List<CityList>>(Validation.city().ToString());
        cityStr = CL.Select(s => s.City).ToList();
        Routing.RegisterRoute(nameof(MobilePay), typeof(MobilePay));
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(xCity.Text))
        {
            var data= cityStr.Where(m => m.ToLower().Contains(xCity.Text.ToLower()));
            if ((data.Any() == true) && (data.First().ToLower() != xCity.Text.ToLower()))
            {
                xFrame.IsVisible = true;
                xList.ItemsSource = data;
            }
            else
            {
                ClrList();
            }
        }
        else
        {
            ClrList();
        }
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        xCity.Text = xList.SelectedItem.ToString();
        ClrList();
    }
    private void ClearListView(object sender, EventArgs e)
    {
        ClrList();
    }

    private void xStoreList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var popUpData = new StorePopup(e.Item as StoreList);
        this.ShowPopup(popUpData);
    }
    private void ClrList()
    {
        xFrame.IsVisible = false;
        xList.ItemsSource = null;
    }
}