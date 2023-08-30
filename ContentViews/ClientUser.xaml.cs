using Innovex_Bank.ContentViews;

namespace Innovex_Bank.ContentViews;

public partial class ClientUser : ContentView
{

    public static BindableProperty First_nameProperty =
    BindableProperty.Create(nameof(First_name), typeof(string), typeof(ClientUser), default(string));

    public static BindableProperty TypeProperty =
    BindableProperty.Create(nameof(Type), typeof(string), typeof(ClientUser), default(string));

    public static BindableProperty Last_nameProperty =
    BindableProperty.Create(nameof(Last_name), typeof(string), typeof(ClientUser), default(string));

    public static BindableProperty Id_numberProperty =
    BindableProperty.Create(nameof(Id_number), typeof(string), typeof(ClientUser), default(string));

    public static BindableProperty Monthly_incomeProperty =
    BindableProperty.Create(nameof(Monthly_income), typeof(string), typeof(ClientUser), default(string));

    public static BindableProperty Account_numberProperty =
BindableProperty.Create(nameof(Account_number), typeof(string), typeof(ClientUser), default(string));

    public static BindableProperty Type_idProperty =
BindableProperty.Create(nameof(Type_id), typeof(string), typeof(ClientUser), default(string));

    public string First_name
    {
        get => (string)GetValue(First_nameProperty);
        set => SetValue(First_nameProperty, value);
    }

    public string Type
    {
        get => (string)GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public string Account_number
    {
        get => (string)GetValue(First_nameProperty);
        set => SetValue(First_nameProperty, value);
    }

    public string Type_id
    {
        get => (string)GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public string Last_name
    {
        get => (string)GetValue(Last_nameProperty);
        set => SetValue(Last_nameProperty, value);
    }

    public string Id_number
    {
        get => (string)GetValue(Id_numberProperty);
        set => SetValue(Id_numberProperty, value);
    }

    public string Monthly_income
    {
        get => (string)GetValue(Monthly_incomeProperty);
        set => SetValue(Monthly_incomeProperty, value);
    }


    public ClientUser()
    {
        InitializeComponent();
        BindingContext = this;
    }
}