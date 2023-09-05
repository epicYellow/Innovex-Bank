namespace Innovex_Bank.ContentViews.AccountManagement;

public partial class TopSectionViewAccManagement : ContentView
{
    public string Title { get; set; }

    public int Total { get; set; }

    public TopSectionViewAccManagement()
    {
        InitializeComponent();
        BindingContext = this;
    }
}