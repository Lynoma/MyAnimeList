   M S B A M L   `   `   `  ����H  DMVVMAnimeList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MVVMAnimeList.ViewsMVVMAnimeList.Views  5      C&clr-namespace:MVVMAnimeList.ViewModelsMVVMAnimeList.ViewModels  5      C&clr-namespace:MVVMAnimeList.ConvertersMVVMAnimeList.Converters  6A   $    MVVMAnimeList.Views.TrelloList   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MVVMAnimeList.Views     5      5vm&clr-namespace:MVVMAnimeList.ViewModels     5      =
converters&clr-namespace:MVVMAnimeList.Converters     6A   -   5          >�Name$
  root��5       � 	Resources 5
      4   .MVVMAnimeList.Converters.TagToCheckedConverter   TagToCheckedConverter��%   &	          5   
   6+   5      .��5      � .+�5   
   �� -   5        ���#F1EFFB$��10q�5   ,    J� 	AllowDrop$
 True��68    J� IsHitTestVisible 6�   �� *IsItemHitTestVisible+ �� ElementName$
 root����5      �� 5      .R�5      ��  �� CornerRadius$ 3��6   $	��272��5      $��78��5      ���#F1EFFB$��8 0 4 0q�5      
�������$��1q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$	 1.5Q�6/      Color$ 	LightGray��5   /   	   	Direction$		 -45Q�5   /   
   RenderingBias$
 Quality=�5   /      ShadowDepth$ 1Q�5   /   ._�5      �  � RowDefinitions 5       �� 5!   "   $
��Auto �60   �� 5"   "   $��* �60   �� 5#   "   $��38 �60   .+�5&      � $��0��6#   .+�5'   "   �� $��A voir��6,   ���#172b4d$��16(�5)   ,   $��DemiBold"�5*   ,   $
��Wrap=�5+   ,    �� Padding$
 8 10q�5,   ,   5-      � 5/      $��1��6#   .+�50   "   �� $��Disabled=�6/   $
��Auto=�51   /   $
 True��52   /   .��53   &   ��  ��Name$ 	MyControl��6T   ��63   �� *
ListItem+��54   *   �� 55   .   .R�56   2   ��  �� Orientation$ Vertical=�6=   $	��Top=�57   =   58   /   ��5:   *   �� 5;   .   .R�5<   2   ��  ��Name$ 
borderDrag��5A   9   -   5        $ 3��5<   9   $��44��5=   9   
�������$��8 0 8 8q�5?   9    �� Padding$ 8 6 8 2q�5@   9   
 � Tag 5D   9   �� *DataContext+ �� RelativeSource ��  �� AncestorType$   MVVMAnimeList.Views.TrelloList"   5E   6     5F   :   $	 1.5Q�6K   $ 	LightGray��5G   K   $		 -90Q�5H   K   $
 Quality=�5I   K   $ 1Q�5J   K    � ContextMenu 5L   6   �� 5M   :    � DataContext 6F   �� *PlacementTarget.Tag+ �� *Self+.@�5N   >   m� -   5        $
��Tags��5N   G   ��6U   ��  �� Path$ FullTagList���5O   B   �� 5P   F    �� 
TargetType" m�6L   .�5Q   J   ��  �� Property � �� �� Value 6c   �� *name+�� 5R   J    �@m�	IsChecked 5S   N   `� 5T   R    `� 	Converter# [  6_   .1�5U   V   �� $
 name�6^   �� 5V   V   $ RightClickedItem�6^    6v   ��  �� Mode$ FindAncestor=�" >�5W   S   5Y   K   5Z   G   5\   ?   m� 5]   >   -   5        $��	Supprimer��5]   G    5_   G   ��  ��  ContextMenu$ PlacementTarget�5`   ;   ._�5b   6   �  5c   :   �� 5d   >   $
��auto �6L   .+�5g   :   � $��0��6?   .+�5h   >   �� ���#172b4d$��14(�5j   H   $��0 0 0 4q�5k   H   ��5h   H   �� *title+5k   H   5l   ;   5m   7   5n   3   5o   /   5q   '   5r   #   5s      5t      5u      5v      5y      5z      5{      