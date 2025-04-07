using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.Models;
using SkiEquipmentRental20.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SkiEquipmentRental20.Pages
{
    public partial class HistoryRentalPage : Page
    {
        public HistoryRentalPage() =>
            InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SER_ViewModel();

            // если в сессии обычный пользователь то, скрываем кнопку удаления аренды
            if (!CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
                Bt_deleteEntry.Visibility = Visibility.Collapsed;

            else
                Bt_addComment.Visibility = Visibility.Collapsed;
        }

        private void Bt_rental_details_Click(object sender, RoutedEventArgs e)
        {
            // если выбранная категория является объектом класса Rental
            if (DgHistoryRental.SelectedItem is Rental selected)
                FrHistoryRental.NavigationService.Navigate(new RentalDetailsPage(selected));
        }

        private void Bt_addComment_Click(object sender, RoutedEventArgs e)
        {
            // если выбранная категория является объектом класса Rental
            if (DgHistoryRental.SelectedItem is Rental selected)
                FrHistoryRental.NavigationService.Navigate(new AddReviewPage(selected.RentalId));
        }
    }
}