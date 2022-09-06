using CommunityToolkit.Mvvm.ComponentModel;

namespace fisPayApp.ViewModels
{
    public partial class BaseVM: ObservableObject
    {
        [ObservableProperty]
        public bool _isBusy;
        [ObservableProperty]
        public string title;
    }
}
