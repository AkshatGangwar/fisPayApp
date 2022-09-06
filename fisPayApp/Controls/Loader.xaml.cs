namespace fisPayApp.Controls;

public partial class Loader : StackLayout
{
	public Loader()
	{
		InitializeComponent();
	}
	public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
		propertyName:nameof(LoadingText),
		returnType: typeof(string),
		defaultValue:"Loading...",
		declaringType:typeof(Loader),
		defaultBindingMode:BindingMode.OneWay);

    public string LoadingText
	{
		get => (string)GetValue(LoadingTextProperty);
		set {SetValue(LoadingTextProperty, value);}
	}
} 