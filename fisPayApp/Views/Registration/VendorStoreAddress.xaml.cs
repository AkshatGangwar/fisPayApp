using CommunityToolkit.Maui.Views;
using fisPayApp.Handlers;
using fisPayApp.ViewModels;
using fisPayApp.Views.PopUps;

namespace fisPayApp.Views.Registration;

public partial class VendorStoreAddress : ContentPage
{
    public VendorStoreAddress()
	{
		InitializeComponent();
        var vendorStoreAddressVM = new VendorStoreAddressVM();
        BindingContext = vendorStoreAddressVM;
        List<string> stateList = new List<string> {"Andhra Pradesh",
                "Arunachal Pradesh",
                "Assam",
                "Bihar",
                "Chhattisgarh",
                "Goa",
                "Gujarat",
                "Haryana",
                "Himachal Pradesh",
                "Jammu and Kashmir",
                "Jharkhand",
                "Karnataka",
                "Kerala",
                "Madhya Pradesh",
                "Maharashtra",
                "Manipur",
                "Meghalaya",
                "Mizoram",
                "Nagaland",
                "Odisha",
                "Punjab",
                "Rajasthan",
                "Sikkim",
                "Tamil Nadu",
                "Telangana",
                "Tripura",
                "Uttarakhand",
                "Uttar Pradesh",
                "West Bengal",
                "Andaman and Nicobar Islands",
                "Chandigarh",
                "Dadra and Nagar Haveli",
                "Daman and Diu",
                "Delhi",
                "Lakshadweep",
                "Puducherry" };
        picker.ItemsSource = stateList;
    }

    void btnClicked(object sender, EventArgs e)
    {
        var popUpData = new PasswordPolicy();
        this.ShowPopup(popUpData);
    }

}