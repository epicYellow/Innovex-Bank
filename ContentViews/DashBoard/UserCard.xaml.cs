namespace Innovex_Bank.ContentViews.DashBoard;

public partial class UserCard : ContentView
{

    public static BindableProperty UsernameProperty =
       BindableProperty.Create(nameof(Username), typeof(string), typeof(UserCard), default(string));

    public static BindableProperty RoleProperty =
       BindableProperty.Create(nameof(Role), typeof(string), typeof(UserCard), default(string));

    public string Username
    {
        get => (string)GetValue(UsernameProperty);
        set => SetValue(UsernameProperty, value);
    }

    public string Role
    {
        get => (string)GetValue(RoleProperty);
        set => SetValue(RoleProperty, value);
    }

    public UserCard()
	{
		InitializeComponent();
        BindingContext = this;
    }
}


