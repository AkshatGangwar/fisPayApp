using CommunityToolkit.Mvvm.Input;
using fisPayApp.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.ViewModels
{
    public partial class AppShellVM : BaseVM
    {
        [RelayCommand]
        public async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
