using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace SkiEquipmentRental20.ViewModels
{
    class AddRentalViewModel : INotifyPropertyChanged
    {
        // реализация наследуемого интерфейса INotifyPropertyChanged для контроля изменения полей и свойств
        public event PropertyChangedEventHandler? PropertyChanged;

        private SkiRentalDBContext _context;

        // поля для добавления аренды
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private Equipment? _selected = null;
        public Equipment? Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
        private DateTime _endDateTime = new();
        public DateTime EndDateTime
        {
            get => _endDateTime;
            set
            {
                _endDateTime = value;
                OnPropertyChanged(nameof(EndDateTime));
            }

        }

        private int _count = 0;
        public int Count
        {
            get => _count;

            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private decimal _totalCost = 0;
        public decimal TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        private decimal _deposit = 0;
        public decimal Deposit
        {
            get => _deposit;
            set
            {
                _deposit = value;
                OnPropertyChanged(nameof(Deposit));
            }
        }

        private ObservableCollection<Equipment> _equipments;
        public ObservableCollection<Equipment> Equipments
        {
            get => _equipments;
            set
            {
                _equipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }

        public AddRentalViewModel()
        {
            _context = new();
            var equip = _context.Equipment.Where(x => x.Status.StatusId == 1 && !x.Isdelited).ToList();
            Equipments = new(equip);
            EndDateTime = DateTime.Now;
            if (!CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
                Login = CurrentUser.User.Email;
        }

        public ICommand AddRentalCommand => new SER_RelayCommand(AddRental, CanAddRental);

        // добавление аренды
        private void AddRental(object? parameter)
        {

            int? user_id = null;

            if (IsEmail(Login))
                user_id = _context.Appusers.FirstOrDefault(x => x.Email == Login)?.UserId;

            else
                user_id = _context.Appusers.FirstOrDefault(x => x.Username == Login)?.UserId;

            if (user_id == null)
            {
                MessageBox.Show("такого пользователя нет");
                return;
            }

            Rental rental = new();

            int rental_id;

            if (_context.Rentals.Any())
                rental_id = _context.Rentals.Max(x => x.RentalId) + 1;

            else
                rental_id = 1;

            rental.RentalId = rental_id;
            rental.UserId = (int)user_id;
            rental.EquipmentId = Selected.EquipmentId;
            rental.StartDatetime = DateTime.Now;
            rental.EndDatetime = EndDateTime;
            rental.TotalCost = TotalCost;
            rental.Deposit = Deposit;

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            // очищаем поля
            if (CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
                Login = "";

            Selected = null;
            EndDateTime = DateTime.Now;
            TotalCost = 0;
            Deposit = 0;
            Count = 0;

            MessageBox.Show("Успешно добавленно");
        }

        private bool CanAddRental(object? parameter) =>
            !string.IsNullOrEmpty(Login) && Selected != null
            && EndDateTime > DateTime.Now && Count >= 1 && Count <= Selected.Quantity;

        private bool IsEmail(string value) =>
            new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(value);

        // если нам поступит дробное число, мы округлим его в большую сторону
        private int Round(double number) =>
            Convert.ToInt32(number) == number ? Convert.ToInt32(number) : Convert.ToInt32(number) + 1;

        protected void OnPropertyChanged(string property)
        {
            // если было изменено выбранное оборудование или кол-во оборудования или время аренды то,
            // пересчитываем итоговую стоимость и депозит
            if (property == nameof(Selected) || property == nameof(Count) || property == nameof(EndDateTime))
            {
                if (Selected != null && Count >= 0 && EndDateTime > DateTime.Now && Count <= Selected.Quantity)
                {
                    // расчитываем итоговую сумму и депозит по формуле - стоимость оборудования за шт * кол-во оборудования * на кол-во дней
                    TotalCost = Selected.Price * Count * Round((EndDateTime - DateTime.Now).TotalDays);
                    Deposit = TotalCost * 0.2m;
                }
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
