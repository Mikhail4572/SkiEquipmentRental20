using SkiEquipmentRental20.Classes;
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
    public partial class AddReviewPage : Page
    {
        private int _rental_id;
        public AddReviewPage(int rental_id)
        {
            InitializeComponent();
            this._rental_id = rental_id;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SER_ViewModel();
            Tb_rental_id.Text = _rental_id.ToString();
            Tb_rental_id.IsEnabled = false;
        }
    }
}
