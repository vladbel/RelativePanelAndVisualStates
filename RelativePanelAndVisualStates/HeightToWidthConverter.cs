using System;
using Windows.UI.Xaml.Data;

namespace RelativePanelAndVisualStates
{
    public sealed class HeightToWidthConverter: IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if ( value is double && (double)value != Double.NaN && (double)value > 0 )
            {
                return (double)value / 1.5;
            }

            return (double)100;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class WidthToHeightConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double && (double)value != Double.NaN && (double)value > 0)
            {
                return (double)value * 1.3;
            }

            return (double)100;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
