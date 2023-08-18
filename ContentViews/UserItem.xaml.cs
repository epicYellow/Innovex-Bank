using Innovex_Bank.ContentViews.DashBoard;

namespace Innovex_Bank.ContentViews;

public partial class UserItem : ContentView
{

    public static BindableProperty AdminUsernameProperty =
     BindableProperty.Create(nameof(AdminUsername), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty AdminTypeProperty =
    BindableProperty.Create(nameof(AdminType), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty AdminNameSurnameProperty =
    BindableProperty.Create(nameof(AdminNameSurname), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty AdminIdNumberProperty =
    BindableProperty.Create(nameof(AdminIdNumber), typeof(string), typeof(TransactionCard), default(string));

    public static BindableProperty AdminIncomeProperty =
    BindableProperty.Create(nameof(AdminIncome), typeof(string), typeof(TransactionCard), default(string));


    public string AdminUsername
    {
        get => (string)GetValue(AdminUsernameProperty);
        set => SetValue(AdminUsernameProperty, value);
    }

    public string AdminType
    {
        get => (string)GetValue(AdminTypeProperty);
        set => SetValue(AdminTypeProperty, value);
    }

    public string AdminNameSurname
    {
        get => (string)GetValue(AdminNameSurnameProperty);
        set => SetValue(AdminNameSurnameProperty, value);
    }

    public string AdminIdNumber
    {
        get => (string)GetValue(AdminIdNumberProperty);
        set => SetValue(AdminIdNumberProperty, value);
    }

    public string AdminIncome
    {
        get => (string)GetValue(AdminIncomeProperty);
        set => SetValue(AdminIncomeProperty, value);
    }


    public UserItem()
	{
		InitializeComponent();
        BindingContext = this;
    }
}