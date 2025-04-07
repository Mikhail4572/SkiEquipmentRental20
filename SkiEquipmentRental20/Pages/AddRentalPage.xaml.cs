using System.Windows;
using System.Windows.Controls;
using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.ViewModels;

namespace SkiEquipmentRental20.Pages
{
    public partial class AddRentalPage : Page
    {
        public AddRentalPage() =>
            InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AddRentalViewModel();
            // если в сессии не админ то, делаем поле для ввода логина неактивным
            if (!CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
                Tb_Login.IsEnabled = false;
        }
    }
}
