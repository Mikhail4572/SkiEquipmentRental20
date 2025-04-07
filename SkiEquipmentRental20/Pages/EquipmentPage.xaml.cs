using SkiEquipmentRental20.Models;
using SkiEquipmentRental20.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace SkiEquipmentRental20.Pages
{
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();
            this.DataContext = new EquipmentEditViewModel();
        }

        private void Bt_edit_Click(object sender, RoutedEventArgs e)
        {
            if (DgEquipments.SelectedItem is Equipment equipment)
                FrEquipments.NavigationService.Navigate(new EditEquipmentItemPage(equipment));
        }

        private void Bt_add_Click(object sender, RoutedEventArgs e) =>
            FrEquipments.NavigationService.Navigate(new EditEquipmentItemPage());
        
    }
}