using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Innovex_Bank.ContentViews;

public partial class ButtonControl : ContentView
{
    public static BindableProperty ButtonTextProperty =
        BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(PageHeader), default(string));

    public static BindableProperty ButtonTypeProperty =
        BindableProperty.Create(nameof(ButtonType), typeof(string), typeof(PageHeader), default(string));

    public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(ButtonControl), Color.FromRgb(255, 0, 0));
    
    public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(ButtonBorderColor), typeof(Color), typeof(ButtonControl), Color.FromRgb(255, 0, 0));
    
    public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(ButtonControl), Color.FromRgb(255, 0, 0));

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }
    public string ButtonType
    {
        get => (string)GetValue(ButtonTypeProperty);
        set => SetValue(ButtonTypeProperty, value);
    }

    public Color ButtonBackgroundColor
    {
        get => (Color)GetValue(ButtonBackgroundColorProperty);
        set => SetValue(ButtonBackgroundColorProperty, value);
    }

    public Color ButtonBorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public Color ButtonTextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public ButtonControl()
    {
        InitializeComponent();
        BindingContext = this;

        PropertyChanged += OnPropertyChanged;

        checkButtonType();
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == ButtonTypeProperty.PropertyName)
        {
            checkButtonType();
        }
    }

    private void checkButtonType()
    {
        Debug.WriteLine(ButtonType);

        if (ButtonType == "Primary")
        {
            ButtonBackgroundColor = Color.FromRgb(75, 86, 210);
            ButtonBorderColor = Color.FromRgba(0, 0, 0, 0);
            ButtonTextColor = Color.FromRgb(255, 255, 255);
        }
        else if (ButtonType == "Secondary")
        {
            ButtonBackgroundColor = Color.FromRgba(0,0,0,0);
            ButtonBorderColor = Color.FromRgb(37, 43, 99);
            ButtonTextColor = Color.FromRgb(37, 43, 99);
        }
    }
}