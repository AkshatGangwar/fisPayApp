using System.Windows.Input;

namespace fisPayApp.Controls;

public partial class BasePopUp : ContentPage
{
    public BasePopUp()
    {
        InitializeComponent();
        this.BackgroundColor = Color.FromArgb("#80000000");
    }

    public static readonly BindableProperty PopupContentProperty = BindableProperty.Create(
        propertyName: nameof(PopupContent),
        returnType: typeof(View),
        declaringType: typeof(BasePopUp),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: PopupContentPropertyChanged);

    private static void PopupContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (BasePopUp)bindable;
        if (newValue != null)
            controls.ContentView.Content = (View)newValue;
    }

    public View PopupContent
    {
        get => (View)GetValue(PopupContentProperty);
        set { SetValue(PopupContentProperty, value); }
    }
}