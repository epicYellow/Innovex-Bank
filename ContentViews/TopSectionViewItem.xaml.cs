namespace Innovex_Bank.ContentViews;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
public partial class TopSectionViewItem : ContentView
{
    public static readonly BindableProperty ChildTitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(TopSectionViewItem), string.Empty);

    public string Title
    {
        get => (string)GetValue(ChildTitleProperty);
        set => SetValue(ChildTitleProperty, value);
    }
    public TopSectionViewItem()
	{
		InitializeComponent();

    }
}