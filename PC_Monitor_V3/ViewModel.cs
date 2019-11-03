using CircularProgressBarApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PC_Monitor_V3
{
    public class ViewModel : ViewModelBase
    {
        private Dictionary<string, (CircularProgressBar cpb, TextBlock tb)> _CircularProgressBar;
        public Dictionary<string, (CircularProgressBar cpb, TextBlock tb)> ProgressBar
        {
            get => _CircularProgressBar;
            set => SetProperty(ref _CircularProgressBar, value);
        }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

                return true;
            }

            return false;
        }
    }
}
