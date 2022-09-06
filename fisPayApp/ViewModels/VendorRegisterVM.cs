using fisPayApp.Views.Registration;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    public partial class VendorRegisterVM:BaseVM
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
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string desc;
        [ObservableProperty]
        private string maalik;
        [ObservableProperty]
        private string email;

        [RelayCommand]
        async void Next()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Desc) && !string.IsNullOrWhiteSpace(Maalik))
            {
                await Shell.Current.GoToAsync($"{nameof(VendorStoreAddress)}?mobileNum={MobileNum}&name={Name}&desc={Desc}&maalik={Maalik}&email={Email}");
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Enter Store name/Email/Store Description/Owner name to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
