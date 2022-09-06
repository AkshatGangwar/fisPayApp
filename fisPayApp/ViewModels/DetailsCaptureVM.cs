using fisPayApp.Views;
using fisPayApp.Views.Registration;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    public partial class DetailsCaptureVM :BaseVM
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
        [RelayCommand]
        async void Vendor()
        {
           await Shell.Current.GoToAsync($"{nameof(VenderRegistration)}?mobileNum={MobileNum}");
        }
        [RelayCommand]
        async void Person()
        {
            await Shell.Current.GoToAsync($"{nameof(PersonRegistration)}?mobileNum={MobileNum}");
        }
    }
}
