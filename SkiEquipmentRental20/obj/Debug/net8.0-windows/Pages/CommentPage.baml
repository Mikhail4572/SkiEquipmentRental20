   M S B A M L   `   `   `  ����O  KSkiEquipmentRental20, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SkiEquipmentRental20.PagesSkiEquipmentRental20.Pages  5      ,    &SkiEquipmentRental20.Pages.CommentPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SkiEquipmentRental20.Pages     5        N� Title$  CommentPage��5	      .��5      � ���#fff � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid     CanUserAddRows$ False��6      
IsReadOnly$
 True��6*      AutoGenerateColumns$ False��5      ��5   <   �� *	Reviews+ �� SelectedItem 5   /   �� *SelectedReview+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Rental.User.LastName+  5      $ Имя��6%    62   �� *Rental.User.FirstName+  5      $ Отчество��6%    67   �� *Rental.User.MiddleName+  5      $ Дата и время��6%    6;   �� *
ReviewDate+  5      $ 
Номер��6%    64   �� *
ReviewId+  5      $ Рейтинг��6%    66   �� *Rating+  5      $ Комментарий��6%    6:   �� *	Comment+5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��1��6.   .+�5      �� -   5        
 ��Name$
 Bt_deleteEntry��5   3   $+��%Удалить комментарий��6   $��10q�6K   $��14(�6W   $��	10 0 10 0q�5   
   ��6   �� *RemoveCommentCommand+5!       � 5"   
   -   5          �Name$ 	FrComment��5"      $��1��6#     � NavigationUIVisibility$ Hidden=�63   5#      5$      