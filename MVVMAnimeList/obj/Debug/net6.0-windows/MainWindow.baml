   M S B A M L   `   `   `  ����H  DMVVMAnimeList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MVVMAnimeListMVVMAnimeList  5   	   9!clr-namespace:MVVMAnimeList.ViewsMVVMAnimeList.Views  63   C&clr-namespace:MVVMAnimeList.ViewModelsMVVMAnimeList.ViewModels  6c   C&clr-namespace:MVVMAnimeList.ConvertersMVVMAnimeList.Converters  6�       MVVMAnimeList.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MVVMAnimeList     5   	   3views!clr-namespace:MVVMAnimeList.Views     63   =
viewmodels&clr-namespace:MVVMAnimeList.ViewModels     6c   =
converters&clr-namespace:MVVMAnimeList.Converters     6�   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  6�     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � AllowsTransparency$
 True��5   	   
������  � Title$ 
MainWindow��5   	   $	��650��6   $
��1200��6)    � 	Resources 5      4   .MVVMAnimeList.Converters.IsSearchPageConverter   IsSearchPageConverter4   .MVVMAnimeList.Converters.IsTrelloPageConverter  IsTrelloPageConverter1   +MVVMAnimeList.Converters.IsTagPageConverter  IsTagPageConverter��%W   &	        &	      &	 &       5   
   6+     5   
   6+     5   
   6(   5      .��5      �� 
������� �� CornerRadius$ 20��6     �� Padding$ 10q�62   ._�5   
   �  5       �� DataType2   ,MVVMAnimeList.ViewModels.TrelloPageViewModel$   MVVMAnimeList.Views.TrelloPage2   ,MVVMAnimeList.ViewModels.SearchPageViewModel$   MVVMAnimeList.Views.SearchPage/   )MVVMAnimeList.ViewModels.TagPageViewModel!	   MVVMAnimeList.Views.TagPage3
   -MVVMAnimeList.ViewModels.DetailsPageViewModel%   MVVMAnimeList.Views.DetailsPage��%,  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *,
 +)�� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5      	  5      �� 5      " 
 6   .R�5         5!      5"      	 � ColumnDefinitions	 5$      �� 5%      $	��150 �6#   �� 5&      $��* �6#   �� 5'      $��50 �6#   .+�5)      �� 
 �� Orientation$
 Vertical=�6   .+�5*      	� $��20(�5,      $��50��5-      $��Center=�5.        RdoBtnNavigation#��[ 5/      $��0,50,0,0q�50       d� 	IsChecked 5*      �� *CurrentViewModel+ �� 	Converter# [   �� Mode$ OneWay=���5+      �� *NavigateToSearch+.��51      ]� $
��True��6    $��Center=�65   .+�52      "  FontAwesome.WPF.ImageAwesome     Icon$ WindowClose=�6*   $��28��6=   $��28��6I   $��0,2,5,0q�6T   �� 53      $��	Recherche��6$   54      56      	� 5:      $��20(�5<      $��50��5=      $��Center=�5>      #��[ 5?       5:      �� *CurrentViewModel+# [ $ OneWay=���5;      �� *NavigateToTrello+.��5A      ]� $
��True��6    $��Center=�65   .+�5B      �� $��Trello��6$   5C      5D      	� 5F      $��20(�5H      $��50��5I      $��Center=�5J      #��[ 5K       5F      �� *CurrentViewModel+# [ $ OneWay=���5G      �� *NavigateToTag+.��5M      ]� $
��True��6    $��Center=�65   .+�5N      �� $
��Tags��6$   5O      5P      5R      �� 5S      -   5         ��Name$ Content��5S      $��1��6S   
������ ��6.   �� *CurrentViewModel+6c   �� 5T      $��2��6   .+�5U      ��   BtnCloseStyle#��[ 6   $��2��6@   5V      5W      5X      5Y      