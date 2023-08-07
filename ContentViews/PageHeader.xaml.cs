namespace Innovex_Bank.ContentViews;

public partial class PageHeader : ContentView
{
	public static BindableProperty PageProperty =
		BindableProperty.Create(nameof(PageTitle), typeof(string), typeof(PageHeader), default(string));

	public string PageTitle
	{
		get => (string)GetValue(PageProperty);
		set => SetValue(PageProperty, value);
	}
	public PageHeader()
	{
		InitializeComponent();
		BindingContext = this;
	}
}