using System.Data;

namespace Innovex_Bank.ContentViews.DashBoard;

public partial class TransactionCard : ContentView
{

    public static BindableProperty AccountIdProperty =
      BindableProperty.Create(nameof(AccountId), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty ClientIdProperty =
      BindableProperty.Create(nameof(ClientId), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty AmountProperty =
      BindableProperty.Create(nameof(Amount), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty TimeStampProperty =
      BindableProperty.Create(nameof(TimeStamp), typeof(string), typeof(TransactionCard), default(string));

    public string AccountId
    {
        get => (string)GetValue(AccountIdProperty);
        set => SetValue(AccountIdProperty, value);
    }

    public string ClientId
    {
        get => (string)GetValue(ClientIdProperty);
        set => SetValue(ClientIdProperty, value);
    }

    public string Amount
    {
        get => (string)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    public string TimeStamp
    {
        get => (string)GetValue(TimeStampProperty);
        set => SetValue(TimeStampProperty, value);
    }
    public TransactionCard()
	{
		InitializeComponent();
        BindingContext = this;
    }
}