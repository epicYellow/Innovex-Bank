using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Innovex_Bank.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Defining our property change handler
        public event PropertyChangedEventHandler PropertyChanged;

        // Detects if it changes
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Sets our change
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

