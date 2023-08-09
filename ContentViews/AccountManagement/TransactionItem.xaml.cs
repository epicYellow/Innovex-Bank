namespace Innovex_Bank.ContentViews.AccountManagement;

public partial class TransactionItem : ContentView
{
    public static BindableProperty TransactionIdProperty =
        BindableProperty.Create(nameof(TransactionId), typeof(string), typeof(AccountUserItem), default(string));

    public static BindableProperty TransactionAmountProperty =
        BindableProperty.Create(nameof(TransactionAmount), typeof(string), typeof(AccountUserItem), default(string));

    public static BindableProperty TransactionFeeProperty =
        BindableProperty.Create(nameof(TransactionFee), typeof(string), typeof(AccountUserItem), default(string));

    public static BindableProperty TransactionTransTypeProperty =
        BindableProperty.Create(nameof(TransactionTransType), typeof(string), typeof(AccountUserItem), default(string));

    public string TransactionId
    {
        get => (string)GetValue(TransactionIdProperty);
        set => SetValue(TransactionIdProperty, value);
    }

    public string TransactionAmount
    {
        get => (string)GetValue(TransactionAmountProperty);
        set => SetValue(TransactionAmountProperty, value);
    }

    public string TransactionFee
    {
        get => (string)GetValue(TransactionFeeProperty);
        set => SetValue(TransactionFeeProperty, value);
    }

    public string TransactionTransType
    {
        get => (string)GetValue(TransactionTransTypeProperty);
        set => SetValue(TransactionTransTypeProperty, value);
    }

    public TransactionItem()
	{
		InitializeComponent();
        BindingContext = this;
	}
}