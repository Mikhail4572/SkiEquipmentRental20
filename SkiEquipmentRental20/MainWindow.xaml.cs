using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkiEquipmentRental20;


public partial class MainWindow : Window
{
    public MainWindow() =>
        InitializeComponent();

    private void Bt_historyRental_Click(object sender, RoutedEventArgs e) =>
        FrMain.NavigationService.Navigate(new HistoryRentalPage());

    private void Bt_addRental_Click(object sender, RoutedEventArgs e) =>
        FrMain.NavigationService.Navigate(new AddRentalPage());

    private void Bt_AddUser_Click(object sender, RoutedEventArgs e) =>
        FrMain.NavigationService.Navigate(new SingUpPage());

    private void Bt_comment_Click(object sender, RoutedEventArgs e) =>
        FrMain.NavigationService.Navigate(new CommentPage());

    private void Bt_equipment_Click(object sender, RoutedEventArgs e) =>
        FrMain.NavigationService.Navigate(new EquipmentPage());

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // если пользователь не админ то, скрываем кнопку добавления юзера
        if (!CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
        {
            Bt_AddUser.Visibility = Visibility.Collapsed;
            Bt_equipment.Visibility = Visibility.Collapsed;
        }

        Tb_currentUser.Text = string.Join(" ", [CurrentUser.User.LastName, CurrentUser.User.FirstName, CurrentUser.User.MiddleName]);
    }

}