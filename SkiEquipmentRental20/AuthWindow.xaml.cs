using SkiEquipmentRental.ViewModels;
using SkiEquipmentRental20.Pages;
using System.Windows;

namespace SkiEquipmentRental20
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            this.DataContext = new AuthViewModel();
        }

        private void Bt_sing_up_Click(object sender, RoutedEventArgs e) =>
            Fr_AuthWindow.NavigationService.Navigate(new SingUpPage());
    }
}
