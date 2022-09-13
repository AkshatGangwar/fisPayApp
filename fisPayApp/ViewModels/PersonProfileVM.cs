using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Handlers;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;

namespace fisPayApp.ViewModels
{
    public partial class PersonProfileVM: BaseVM
    {
        [ObservableProperty]
        private string username= App.UserDetails.name;
        [ObservableProperty]
        private string useremail = App.UserDetails.emailId;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        public async void UpdatePersonProfile()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Useremail))
            {
                Indicator = "True";
                var response = await loginRepository.UpdatePersonProfile(new UpdateUserProfile
                {
                    Name = Username,
                    Id = App.UserDetails.userId,
                    Email = Useremail,
                });
                if (response!=null)
                {
                    if (response.resultCode.statusCode == "200")
                    {
                        Indicator = "False";
                        App.UserDetails.name = Username;
                        App.UserDetails.emailId = Useremail;
                        await AppConstant.AddFlyoutMenusDetails();
                        Validation.toastmsg("Success!", "S", 18);
                    }
                    else
                    {
                        Indicator = "False";
                        Validation.toastmsg("Error", "S", 18);
                    }
                }
                else
                {
                    Indicator = "False";
                    Validation.toastmsg("Error", "S", 18);
                }
            }
            else
            {
                Validation.toastmsg("Enter Name/Email to Proceed...", "S", 18);
            }
        }
    }
}
