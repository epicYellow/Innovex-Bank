namespace Innovex_Bank.ContentViews.DashBoard;

public partial class DashBoardFundsPool : ContentView
{

    public static BindableProperty TotalFundsProperty =
    BindableProperty.Create(nameof(TotalFunds), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty TotalWithdrawnProperty =
    BindableProperty.Create(nameof(TotalWithdrawn), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty TotalDespositedProperty =
    BindableProperty.Create(nameof(TotalDesposited), typeof(string), typeof(TransactionCard), default(string));

    public string TotalFunds
    {
        get => (string)GetValue(TotalFundsProperty);
        set => SetValue(TotalFundsProperty, value);
    }

    public string TotalWithdrawn
    {
        get => (string)GetValue(TotalWithdrawnProperty);
        set => SetValue(TotalWithdrawnProperty, value);
    }

    public string TotalDesposited
    {
        get => (string)GetValue(TotalDespositedProperty);
        set => SetValue(TotalDespositedProperty, value);
    }
    public DashBoardFundsPool()
	{
		InitializeComponent();
        BindingContext = this;
    }
}