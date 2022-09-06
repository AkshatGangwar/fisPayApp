using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    [QueryProperty(nameof(Name), "name")]
    [QueryProperty(nameof(Desc), "desc")]
    [QueryProperty(nameof(Maalik), "maalik")]
    [QueryProperty(nameof(Email), "email")]
    public partial class VendorStoreAddressVM: BaseVM
    {
        private string mobileNum;
        public string MobileNum
        {
            get => mobileNum;
            set
            {
                mobileNum = value;
                OnPropertyChanged();
            }
        }
        
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string desc;
        public string Desc
        {
            get => desc;
            set
            {
                desc = value;
                OnPropertyChanged();
            }
        }

        private string maalik;
        public string Maalik
        {
            get => maalik;
            set
            {
                maalik = value;
                OnPropertyChanged();
            }
        }
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        private string address;
        [ObservableProperty]
        private string city;
        [ObservableProperty]
        private string district;
        [ObservableProperty]
        private string state;
        [ObservableProperty]
        private string landmark;
        [ObservableProperty]
        private string zip;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void SignUp()
        {
            if (!string.IsNullOrWhiteSpace(Address) && !string.IsNullOrWhiteSpace(City) && !string.IsNullOrWhiteSpace(District) && !string.IsNullOrWhiteSpace(State) && !string.IsNullOrWhiteSpace(Landmark) && !string.IsNullOrWhiteSpace(Zip) && !string.IsNullOrWhiteSpace(Password))
            {
                Indicator = "True";
                var response = await loginRepository.RegisterVendor(new VendorProfileData
                {
                    name = Maalik,
                    mobile = MobileNum,
                    password = Password,
                    email = Email,
                    storeName = Name,
                    description = Desc,
                    city = City,
                    state = State,
                    district = District,
                    country = "IN",
                    address = Address,
                    zipcode = Zip,
                    landmark = Landmark,
                    userType="2",
                    isActive="true"
                });
                if (response.resultCode.statusCode == "200")
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Success!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }

                else
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Error!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Enter Address/City/District/State/Landmark/PIN Code/Password to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
        [RelayCommand]
        async void LoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
