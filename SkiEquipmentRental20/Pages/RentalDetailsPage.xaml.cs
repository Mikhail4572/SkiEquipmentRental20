using SkiEquipmentRental20.Models;
using SkiEquipmentRental20.ViewModels;
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

namespace SkiEquipmentRental20.Pages
{
    public partial class RentalDetailsPage : Page
    {
        // категория выбранная в DataGrid
        private Rental _rental;
        public RentalDetailsPage(Rental rental)
        {
            InitializeComponent();
            this._rental = rental;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Tb_LastName.Text = _rental.User.LastName;
            Tb_FirstName.Text = _rental.User.FirstName;
            Tb_MiddleName.Text = !string.IsNullOrEmpty(_rental.User.MiddleName) ? _rental.User.MiddleName : "";
            Tb_Email.Text = _rental.User.Email;
            Tb_PhoneNumber.Text = !string.IsNullOrEmpty(_rental.User.PhoneNumber) ? _rental.User.PhoneNumber : "";
            Tb_Name.Text = _rental.Equipment.Name;
            Tb_Type.Text = _rental.Equipment.Type;
            Tb_Price.Text = _rental.Equipment.Price + "₽";
            Tb_Quantity.Text = _rental.Equipment.Quantity.ToString();
            Tb_StartDatetime.Text = _rental.StartDatetime.ToString("dd/MM/yyyy HH:mm");
            Tb_EndDatetime.Text = _rental.EndDatetime.ToString("dd/MM/yyyy HH:mm");
            Tb_TotalCost.Text = _rental.TotalCost + "₽";
            Tb_Deposit.Text = _rental.Deposit + "₽";
        }

        private void SvgImg_back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) =>
            this.Content = null;
    }
}
