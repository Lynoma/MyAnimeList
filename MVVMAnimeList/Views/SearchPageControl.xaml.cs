using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMAnimeList.Views
{
    /// <summary>
    /// Logique d'interaction pour SearchPageControl.xaml
    /// </summary>
    public partial class SearchPageControl : UserControl
    {


        public ICommand Navigate
        {
            get { return (ICommand)GetValue(NavigateProperty); }
            set { SetValue(NavigateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Navigate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigateProperty =
            DependencyProperty.Register("Navigate", typeof(ICommand), typeof(SearchPageControl), new PropertyMetadata(null));

        public object SelectionChanged
        {
            get { return (object)GetValue(SelectionChangedProperty); }
            set { SetValue(SelectionChangedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Navigate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionChangedProperty =
            DependencyProperty.Register("SelectionChanged", typeof(object), typeof(SearchPageControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public SearchPageControl()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Navigate.Execute(null);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListView)sender;
            if(item.SelectedItem != null)
                SelectionChanged = (AnimeItem)item.SelectedItems[0];
        }
    }
}
