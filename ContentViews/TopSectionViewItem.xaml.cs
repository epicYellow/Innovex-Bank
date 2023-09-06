namespace Innovex_Bank.ContentViews;
public partial class TopSectionViewItem : ContentView
{
    public string Title { get; set; }
    public int Total { get; set; }

    public int TotalGoldCheque { get; set; }
    public int TotalDiamondAccounts { get; set; }
    public int TotalTaxFreeAccounts { get; set; }
    public int TotalEasyAccessSavings { get; set; }

    public TopSectionViewItem()
	{
		InitializeComponent();
        BindingContext = this;
    }
}