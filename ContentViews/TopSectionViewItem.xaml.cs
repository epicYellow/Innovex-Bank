namespace Innovex_Bank.ContentViews;
public partial class TopSectionViewItem : ContentView
{
    public static BindableProperty TopSectionTitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(PageHeader), default(string));

    public static BindableProperty TopSectionTotalProperty =
        BindableProperty.Create(nameof(Total), typeof(int), typeof(PageHeader), default(int));

    public string Title
    {
        get => (string)GetValue(TopSectionTitleProperty);
        set => SetValue(TopSectionTitleProperty, value);
    }

    public int Total
    {
        get => (int)GetValue(TopSectionTotalProperty);
        set => SetValue(TopSectionTotalProperty, value);
    }
    public TopSectionViewItem()
	{
		InitializeComponent();
        BindingContext = this;
    }
}