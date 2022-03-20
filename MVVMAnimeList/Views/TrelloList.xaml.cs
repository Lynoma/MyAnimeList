using MVVMAnimeList.Commands;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour TrelloList.xaml
    /// </summary>
    public partial class TrelloList : UserControl
    {
        #region Properties
        #region Drop and Incoming
        public static readonly DependencyProperty IncomingItemProperty =
            DependencyProperty.Register("IncomingItem", typeof(object), typeof(TrelloList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object IncomingItem
        {
            get { return (object)GetValue(IncomingItemProperty); }
            set { SetValue(IncomingItemProperty, value); }
        }

        public static readonly DependencyProperty ItemDropCommandProperty =
            DependencyProperty.Register("ItemDropCommand", typeof(ICommand), typeof(TrelloList), new PropertyMetadata(null));
        public ICommand ItemDropCommand
        {
            get { return (ICommand)GetValue(ItemDropCommandProperty); }
            set { SetValue(ItemDropCommandProperty, value); }
        }
        #endregion

        #region Removed and Removed

        public static readonly DependencyProperty RemovedItemProperty =
            DependencyProperty.Register("RemovedItem", typeof(object), typeof(TrelloList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object RemovedItem
        {
            get { return (object)GetValue(RemovedItemProperty); }
            set { SetValue(RemovedItemProperty, value); }
        }

        public static readonly DependencyProperty ItemRemovedCommandProperty =
            DependencyProperty.Register("ItemRemovedCommand", typeof(ICommand), typeof(TrelloList), new PropertyMetadata(null));
        public ICommand ItemRemovedCommand
        {
            get { return (ICommand)GetValue(ItemRemovedCommandProperty); }
            set { SetValue(ItemRemovedCommandProperty, value); }
        }

        #endregion
        #region


        public ICommand DeleteItem
        {
            get { return (ICommand)GetValue(DeleteItemProperty); }
            set { SetValue(DeleteItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteItemProperty =
            DependencyProperty.Register("DeleteItem", typeof(ICommand), typeof(TrelloList), new PropertyMetadata(null));


        #endregion

        #region IsHitTestVisible

        public static readonly DependencyProperty IsItemHitTestVisibleProperty =
            DependencyProperty.Register("IsItemHitTestsVisible", typeof(bool), typeof(TrelloList), new PropertyMetadata(true));
        public bool IsItemHitTestVisible
        {
            get { return (bool)GetValue(IsItemHitTestVisibleProperty); }
            set { SetValue(IsItemHitTestVisibleProperty, value); }
        }
        #endregion

        public static readonly DependencyProperty RightClickedItemProperty =
           DependencyProperty.Register("RightClickedItem", typeof(object), typeof(TrelloList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object RightClickedItem
        {
            get { return (object)GetValue(RightClickedItemProperty); }
            set { SetValue(RightClickedItemProperty, value); }
        }

        public static readonly DependencyProperty ClickedTagProperty =
           DependencyProperty.Register("ClickedTag", typeof(object), typeof(TrelloList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object ClickedTag
        {
            get { return (object)GetValue(ClickedTagProperty); }
            set { SetValue(ClickedTagProperty, value); }
        }


        public static readonly DependencyProperty RemoveTagItemCommandProperty =
            DependencyProperty.Register("RemoveTagItemCommand", typeof(ICommand), typeof(TrelloList), new PropertyMetadata(null));
        public ICommand RemoveTagItemCommand
        {
            get { return (ICommand)GetValue(RemoveTagItemCommandProperty); }
            set { SetValue(RemoveTagItemCommandProperty, value); }
        }

        public static readonly DependencyProperty AddTagItemCommandProperty =
            DependencyProperty.Register("AddTagItemCommand", typeof(ICommand), typeof(TrelloList), new PropertyMetadata(null));
        public ICommand AddTagItemCommand
        {
            get { return (ICommand)GetValue(AddTagItemCommandProperty); }
            set { SetValue(AddTagItemCommandProperty, value); }
        }

        #endregion
        public TrelloList()
        {
            InitializeComponent();
        }

        private void borderDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed &&
                sender is FrameworkElement frameworkElement)
            {
                IsItemHitTestVisible = false;
                DragDrop.DoDragDrop(frameworkElement, new DataObject(DataFormats.Serializable, frameworkElement.DataContext), DragDropEffects.Move);
                IsItemHitTestVisible = true;
            }
        }

        private void ScrollViewer_Drop(object sender, DragEventArgs e)
        {
            if(ItemDropCommand?.CanExecute(null) ?? false)
            {
                IncomingItem = e.Data.GetData(DataFormats.Serializable);
                ItemDropCommand.Execute(null);
            }
        }

        private void ScrollViewer_DragLeave(object sender, DragEventArgs e)
        {
            if (ItemRemovedCommand?.CanExecute(null) ?? false)
            {
                RemovedItem = e.Data.GetData(DataFormats.Serializable);
                ItemRemovedCommand.Execute(null);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (sender as FrameworkElement).Tag;
            var test = ((Border)menuItem).DataContext;
            TrelloItem trelloItem = (TrelloItem)test;

            DeleteItem?.Execute(trelloItem);
        }

        private void ContextMenu_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var test = ((Border)sender).DataContext;
            TrelloItem trelloItem = (TrelloItem) test;
            RightClickedItem = trelloItem;
        }

        private void Cick_Tag_MenuItem(object sender, RoutedEventArgs e)
        {
            var contextmenu = (MenuItem)e.OriginalSource;
            var data = contextmenu.DataContext;
            ClickedTag = data;

            var check = contextmenu.IsChecked;
            if (check)
            {
                RemoveTagItemCommand.Execute(null);
            }
            else
            {
                AddTagItemCommand.Execute(null);
            }
        }
    }
}
