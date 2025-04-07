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
using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.ViewModels;

namespace SkiEquipmentRental20.Pages
{
    /// <summary>
    /// Логика взаимодействия для SingUpPage.xaml
    /// </summary>
    public partial class SingUpPage : Page
    {
        public SingUpPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // подключаем ViewModel регистрации
            this.DataContext = new SingUpViewModel();
            // если обычный пользователь регистрируется то, от него скрывается выбор роли
            // если админ регистрирует кого-то, то условие не пройдёт и ему отобразится
            // ComboBox и TextBlock
            if (CurrentUser.User == null || !CurrentUser.User.Role.
                Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
            {
                Cb_Roles.Visibility = Visibility.Collapsed;
                Tb_Roles.Visibility = Visibility.Collapsed;
            }

            // добавляем подсказку на пароль
            Tb_password.ToolTip = "Минимум одна цифра.\r\n\r\nМинимум одна заглавная буква.\r\n\r\nМинимум одна прописная буква.\r\n\r\nМинимум один специальный символ.\r\n\r\nОбщая длина пароля — минимум 8 символов.";
        }
        private void SvgImg_back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) =>
            this.Content = null;
    }
}
