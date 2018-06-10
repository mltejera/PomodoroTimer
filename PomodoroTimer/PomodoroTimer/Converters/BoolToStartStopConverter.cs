using System;
using Windows.UI.Xaml.Data;

namespace PomodoroTimer.Converters
{
    class BoolToStartStopConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool valAsBool = (bool)value;

            if (valAsBool)
            {
                return "Stop";
            }
            else
            {
                return "Play";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
