   M S B A M L   `   `   `  ����O  KSkiEquipmentRental20, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SkiEquipmentRental20.PagesSkiEquipmentRental20.Pages  5      +    %SkiEquipmentRental20.Pages.SingUpPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^SharpVectors.Converters.Wpf, Version=1.8.4.2, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/  5      4local(clr-namespace:SkiEquipmentRental20.Pages  5      -   5          N� Title$  
SingUpPage��5
      .��5      � ���#fff � ColumnDefinitions 5   
   �� 5      �� 5      $
��1.5* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      .+�5   
   � $
��Left=�6   $��10q�6*   .+�5      (  "SharpVectors.Converters.SvgViewbox  -   5          Name$ SvgImg_back��5         Source$  /Icons/arrow_back_50dp.svg?�6e   5      �� 5   
   $��2��6    �� Padding$ 20q�6"   $��Center=�6/   $��1��6J   $��2q�5      ���#1f1f1f �� CornerRadius$ 2��62   ._�5      �� .+�5       �� $��0 0 0 10q�6   $��Регистрация��6*   $��Center=�6@   $��24(�6d   �� 5!      -   5         ��Name$ Tb_Roles��5!   .    �� Padding$ 5 0 0 0q�6   $��Должность��6@   $��14(�6Q   �� 5"      -   5        	 ��Name$	 Cb_Roles��5"      
 �� DisplayMemberPath$
 Position��5#   9    �� SelectedItem 5"   -   �� *
RoleUser+ �� Mode$ TwoWay=���5#      �� *Roles+69   �� 5$      $ 5 0 0 0q�6   $��Фамилия��6.   $��14(�6=   �� 5%      $��14(�6   ��6(   �� *
LastName+�� 5&      $ 5 0 0 0q�6   $��Имя��6.   $��14(�69   �� 5'      $��14(�6   ��6(   �� *	FirstName+�� 5(      $ 5 0 0 0q�6   $��Отчество��6.   $��14(�6>   �� 5)      $��14(�6   ��6(   �� *
MiddleName+�� 5*      $ 5 0 0 0q�6   $��
Почта��6.   $��14(�6;   �� 5+      $��14(�6   ��6(   �� *Email+�� 5,      $ 5 0 0 0q�6   $��
Логин��6.   $��14(�6;   �� 5-      $��14(�6   ��6(   �� *
Username+�� 5.      $ 5 0 0 0q�6   $��Пароль��6.   $��14(�6<   �� 5/      -   5         ��Name$ Tb_password��5/   (   $��14(�6   ��6=   �� *
Password+�� 50      $ 5 0 0 0q�6   $!��Номер телефона��6.   $��14(�6D   �� 51      $��14(�6   ��6(   �� *PhoneNumber+�� 52      $��0 5 0 5q�6   $*��$Зарегистрироваться��6M   $��16(�6j   $��0 5 0 0q�6x   ��6+   �� *SingUpCommand+6x   53      54      55      56      