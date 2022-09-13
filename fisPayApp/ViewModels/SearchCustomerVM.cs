using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Handlers;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using fisPayApp.Views.Payments;

namespace fisPayApp.ViewModels
{
    public partial class SearchCustomerVM : BaseVM
    {
        [ObservableProperty]
        private string mobileNum;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string userId;
        [ObservableProperty]
        private string indicator = "False";
        [ObservableProperty]
        private string userFrame = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void GetUsrDeatils()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(mobileNum))
                {
                    Indicator = "True";
                    UserFrame = "False";
                    var response = await loginRepository.GetUserIdByMobile(MobileNum);
                    if (response != null)
                    {
                        Indicator = "False";
                        UserFrame = "True";
                        Name = response.dataObject.data.Name;
                        UserId = response.dataObject.data.userId;
                    }
                    else
                    {
                        Indicator = "False";
                        UserFrame = "False";
                        Validation.toastmsg("Error", "S", 18);
                    }
                }
                else
                {
                    Validation.toastmsg("Please Enter Mobile Number.", "S", 18);
                }
            }
            catch (Exception)
            {
                Indicator = "False";
                UserFrame = "False";
                Validation.toastmsg("Error", "S", 18);
            }
            finally
            {
                IsBusy = false;
            }
        }
        [RelayCommand]
        async void GetPaymentPage()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                await Shell.Current.GoToAsync($"{nameof(MobilePay)}?name={Name}&userId={UserId}");
        }
    }
}
