   M S B A M L   `   `   `  ����O  KSkiEquipmentRental20, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SkiEquipmentRental20.PagesSkiEquipmentRental20.Pages  5      2    ,SkiEquipmentRental20.Pages.HistoryRentalPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SkiEquipmentRental20.Pages     5      -   5          N� Title$  HistoryRentalPage��5	      -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=�6!   .��5      � ���#fff � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgHistoryRental��5   5      CanUserAddRows$ False��5         
IsReadOnly$
 True��6*      AutoGenerateColumns$ False��6<    �� SelectedItem 5      �� *
Selected+��6N   �� *	Rentals+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Номер��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *
RentalId+  5      $	 Фамилия��6%   
 66   �� *User.LastName+  5      $	 Имя��6%   
 62   �� *User.FirstName+  5      $	 Отчество��6%   
 67   �� *User.MiddleName+  5      $)	 #Дата и время начала��6%   
 6B   �� *StartDatetime+  5      $'	 !Дата и время конца��6%   
 6A   �� *EndDatetime+  5      $	 
Сумма��6%   
 64   �� *	TotalCost+5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� -   5         ��Name$ Bt_rental_details��5   5   $*��$Подробнее об аренде��5      $��10q�63   $��14(�6?   $��	10 0 10 0q�6M   �� 5       -   5        $ Bt_deleteEntry��5    .   $!��Удалить запись��6   $��10q�6F   $��14(�6R   $��	10 0 10 0q�5!      ��6)   �� *DeleteEntryCommand+�� 5"      -   5        $ Bt_addComment��5#   E   $��10q�5"      $��14(�6!   $��	10 0 10 0q�6/   $-��'Добавить комментарий��5#   
   6E   5%       � 5&   
   -   5          �Name$ FrHistoryRental��5&   !   $��2��6     � NavigationUIVisibility$ Hidden=�6:   5'      5(      