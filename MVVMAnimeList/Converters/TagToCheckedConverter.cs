using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVMAnimeList.Converters
{
    public class TagToCheckedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TrelloItem item = (TrelloItem)values[1];
            List<string> names = new List<string>();

            foreach (Tag tag in item.Tags)
            {
                names.Add(tag.name);
            }

            if (names.Contains((string)values[0]))
            {
                return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
