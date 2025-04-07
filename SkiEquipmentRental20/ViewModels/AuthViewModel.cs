using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.Models;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace SkiEquipmentRental.ViewModels
{ 
    class AuthViewModel : INotifyPropertyChanged
    {
        private SkiRentalDBContext _context;

        public AuthViewModel() =>
            _context = new();

        // реализация наследуемого интерфейса INotifyPropertyChanged для контроля изменения полей и свойств
        public event PropertyChangedEventHandler? PropertyChanged;

        // создаём событие на нашу кнопку, если простыми словами
        public ICommand AuthCommand => new SER_RelayCommand(AuthUser, CanAuth);

        // поля для входа
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
      
        // метод авторизации в системе
        private async void AuthUser(object? parameter)
        {
            Appuser? user;
            // проверяем что ввёл пользователь почту или логин(username)
            if (IsEmail(Login))            
                user = _context.Appusers.FirstOrDefault(x => x.Email == Login && x.Password == Password);
            
            else 
                user = _context.Appusers.FirstOrDefault(x => x.Username == Login && x.Password == Password);

            // если результат запроса null то значит - пользователь не найден
            if (user == null)
            {
                MessageBox.Show("неверный логин или пароль");
                return;
            }

            CurrentUser.User = user;

            // открываем главное окно
            NavigationService.NavigateToMainWindow();
            // закрываем окно авторизации
            NavigationService.CloseAuthWindow();
        }

        // метод проверки на валидность почты
        private bool IsEmail(string value) => 
            new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(value);

        // метод проверки полей на соответствие
        private bool CanAuth(object? parameter) =>
            !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        // метод для информирования системы об изменениях
        protected void OnPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
