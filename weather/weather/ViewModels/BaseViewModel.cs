using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using weather.Interface;
using weather.Service;
using Xamarin.Forms;

namespace weather.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
   
    }
}