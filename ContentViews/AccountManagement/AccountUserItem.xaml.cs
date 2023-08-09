namespace Innovex_Bank.ContentViews.AccountManagement;

public partial class AccountUserItem : ContentView
{
	public static BindableProperty UserNameItemProperty =
		BindableProperty.Create(nameof(UserNameItem), typeof(string), typeof(AccountUserItem), default(string));

    public static BindableProperty UserTypeItemProperty =
        BindableProperty.Create(nameof(UserTypeItem), typeof(string), typeof(AccountUserItem), default(string));

    public string UserNameItem
    {
		get => (string)GetValue(UserNameItemProperty);
		set => SetValue(UserNameItemProperty, value);
	}

    public string UserTypeItem
    {
        get => (string)GetValue(UserTypeItemProperty);
        set => SetValue(UserTypeItemProperty, value);
    }
    public AccountUserItem()
	{
		InitializeComponent();
        BindingContext = this;
	}
}