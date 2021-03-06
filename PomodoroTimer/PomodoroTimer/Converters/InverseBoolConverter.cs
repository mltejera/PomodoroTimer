﻿using System;
using Windows.UI.Xaml.Data;

namespace PomodoroTimer.Converters
{
    class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool valAsBool = (bool)value;

            return !valAsBool;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
