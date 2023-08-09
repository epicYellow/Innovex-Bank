using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.ViewModels;

public partial class LoginVModel : ObservableObject
{
    public LoginVModel()
    {
        //items are users
        Items = new ObservableCollection<string>();
    }


    //Items can be login details
    [ObservableProperty]
    ObservableCollection<string> items;

    //text is input feild
    [ObservableProperty]
    string text;


    //adds text to items, can match with backend to verify user.
    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;
        Items.Add(Text);
        Text = string.Empty;
    }
}

