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
using SkiEquipmentRental20.Models;
using SkiEquipmentRental20.ViewModels;

namespace SkiEquipmentRental20.Pages
{
    public partial class EditEquipmentItemPage : Page
    {
        
        string _header_page = "Редактирование";
        string _button_action_content = "Изменить";

        public EditEquipmentItemPage(Equipment equipment)
        {
            InitializeComponent();
            this.DataContext = new EquipmentEditViewModel(equipment);
        }

        public EditEquipmentItemPage()
        {
            InitializeComponent();
            this.DataContext = new EquipmentEditViewModel();
            _header_page = "Добавление оборудования";
            _button_action_content = "Добавить";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Lb_header.Content = _header_page;
            Bt_action.Content = _button_action_content;
        }

        private void SvgImg_back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) =>
            this.Content = null;
    }
}
