using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;

namespace PomodoroTimer.Converters
{
    class BoolToStartStopSymbolIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool valAsBool = (bool)value;

            if (valAsBool)
            {
                return new SymbolIcon(Symbol.Stop);
            }
            else
            {
                return new SymbolIcon(Symbol.Play);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
