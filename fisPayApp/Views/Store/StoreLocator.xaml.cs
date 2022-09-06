using fisPayApp.Handlers;
using fisPayApp.Models;
using fisPayApp.ViewModels;
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
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(xCity.Text))
        {
            xFrame.IsVisible = true;
            xList.ItemsSource = cityStr.Where(m => m.ToLower().Contains(xCity.Text.ToLower()));
        }
        else
        {
            xFrame.IsVisible = false;
            xList.ItemsSource = null;
        }
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        xCity.Text = xList.SelectedItem.ToString();
        xFrame.IsVisible = false;
        xList.ItemsSource = null;
    }
}