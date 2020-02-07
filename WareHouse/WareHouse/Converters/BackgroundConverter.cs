using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WareHouse.Converters
{
    public sealed class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            var item = (ListViewItem)value;
            var listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            if (listView != null)
            {
                var index = listView.ItemContainerGenerator.IndexFromContainer(item);
                if (index % 2 == 0)
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#404955"));
                }
            }
            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#292F37"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
