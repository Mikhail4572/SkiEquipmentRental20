using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.Models;

namespace SkiEquipmentRental20.ViewModels
{
    class SingUpViewModel : INotifyPropertyChanged
    {
        // реализация наследуемого интерфейса INotifyPropertyChanged для контроля изменения полей и свойств
        public event PropertyChangedEventHandler? PropertyChanged;

        // наш контекст данных, по сути наша база данных
        private SkiRentalDBContext _context;

        // коллекция ролей
        private ObservableCollection<Role> _roles;
        public ObservableCollection<Role> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        // поля для добавления юзера
        private Role? _roleUser = null;

        public Role? RoleUser
        {
            get => _roleUser;
            set
            {
                _roleUser = value;
                OnPropertyChanged(nameof(RoleUser));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _middleName = "";
        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public SingUpViewModel()
        {
            // выделяем память
            _context = new();
            // заполняем коллекцию ролей
            Roles = [.. _context.Roles];
        }

        // создаём событие на нашу кнопку, если простыми словами
        public ICommand SingUpCommand => new SER_RelayCommand(SingUp, CanSingUp);

        // метод регистрации
        private void SingUp(object? parameter)
        {
            var res = _context.Appusers.FirstOrDefault(x => x.Email == Email);

            // если такой Email то, выводим сообщение об ошибке
            if (res != null)
            {
                MessageBox.Show("такая почта уже есть");
                return;
            }

            var res1 = _context.Appusers.FirstOrDefault(x => x.Username == Username);

            // если такой Username то, выводим сообщение об ошибке
            if (res1 != null)
            {
                MessageBox.Show("такой логин уже есть");
                return;
            }

            int user_id;

            // есть ли записи в таблице AppUsers
            if (_context.Appusers.Any())
                user_id = _context.Appusers.Max(x => x.UserId) + 1;

            else
                user_id = 1;

            // создаём и инициализируем объект класса
            Appuser user = new()
            {
                UserId = user_id,
                LastName = LastName,
                FirstName = FirstName,
                MiddleName = MiddleName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Username = Username,
                Password = Password,
                RoleId = RoleUser != null ? RoleUser.RoleId : 1
            };

            // добавляем запись в бд
            _context.Appusers.Add(user);
            // сохраняем изменения
            _context.SaveChanges();

            // смотрим, если это была регистрация пользователя из AuthWindow то,
            // наш CurrentUser.User будет null
            if (CurrentUser.User == null)
            {
                MessageBox.Show("Добро пожаловать");
                CurrentUser.User = user;

                // открываем главное окно
                NavigationService.NavigateToMainWindow();
                // закрываем окно авторизации
                NavigationService.CloseAuthWindow();
            }

            // если же это админ добавил юзера то, выводим сообщение об успехе
            else
                MessageBox.Show("Пользователь добавлен");
        }

        // проверка на валидность пароля
        private bool IsPassword(string value) =>
            new Regex(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z])(?=.*[\W_]).{8,}$").IsMatch(value);

        // проверка на валидность номера телефона
        private bool IsPhoneNumber(string value) =>
            new Regex(@"^(\+7|8)\d{10}$").IsMatch(value);

        // проверка на валидность почты
        private bool IsEmail(string value) =>
            new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(value);

        // метод проверки полей на соответствие
        private bool CanSingUp(object? parameter) =>
            !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(FirstName)
            && !string.IsNullOrEmpty(Email) && IsEmail(Email) 
            && !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password)
            && IsPassword(Password) && !string.IsNullOrEmpty(PhoneNumber) 
            && IsPhoneNumber(PhoneNumber);

        // метод для информирования системы об изменениях
        protected void OnPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
