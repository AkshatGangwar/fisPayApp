using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;
using fisPayApp.Handlers;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    public partial class PersonRegisterVM:BaseVM
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
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void SignUp()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                if (Validation.ValidatePassword(Password))
                {
                    Indicator = "True";
                    var response = await loginRepository.RegisterPerson(new PersonProfileData
                    {
                        name = Name,
                        mobile = MobileNum,
                        password = Password,
                        email = Email,
                        userType = "1",
                        isActive = "true"
                    });
                    if (response.resultCode.statusCode == "200")
                    {
                        Indicator = "False";
                        Validation.toastmsg("Success!", "S", 18);
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    }

                    else
                    {
                        Indicator = "False";
                        Validation.toastmsg("Error", "S", 18);
                    }
                }
                else
                {
                    Validation.toastmsg("Invalid Password!", "S", 18);
                }
            }
            else
            {
                Validation.toastmsg("Enter Name/Email/Password to Proceed...", "S", 18);
            }
        }
        [RelayCommand]
        async void LoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
