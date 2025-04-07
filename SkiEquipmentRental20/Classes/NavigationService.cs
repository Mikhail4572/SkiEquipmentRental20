using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiEquipmentRental20.Classes
{
    public static class NavigationService
    {
        // закрытие окна регистрации
        public static void CloseAuthWindow() =>
            Application.Current.Windows.OfType<AuthWindow>()
            .FirstOrDefault()?.Close();

        // открытие главного окна
        public static void NavigateToMainWindow() =>
             new MainWindow().Show();

    }
}
