using System.ComponentModel;
using Windows.UI.Core;
using Windows.UI.Xaml;

//////////////////////////////////////
//NOTE: BOILER PLATE FROM MSDN
//////////////////////////////////////

namespace PomodoroTimerLogic.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
