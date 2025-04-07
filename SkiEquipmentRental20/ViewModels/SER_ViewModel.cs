using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Data;
using SkiEquipmentRental20.Models;
using SkiEquipmentRental20.Classes;
using System.Windows;
using System.Text.RegularExpressions;

namespace SkiEquipmentRental20.ViewModels
{
    class SER_ViewModel : INotifyPropertyChanged
    {
        // реализация наследуемого интерфейса INotifyPropertyChanged для контроля изменения полей и свойств
        public event PropertyChangedEventHandler? PropertyChanged;

        // наш контекст данных, по сути наша база данных
        private SkiRentalDBContext _context;

        // коллекция аренд
        private ObservableCollection<Rental> _rentals;
        public ObservableCollection<Rental> Rentals
        {
            get => _rentals;
            set
            {
                _rentals = value;
                OnPropertyChanged(nameof(Rentals));
            }
        }

        // выбранная аренда для удаления
        private Rental _selected;
        public Rental Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        private ObservableCollection<Review> _reviews;
        public ObservableCollection<Review> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged(nameof(Reviews));
            }
        }

        // поля для добавления комментария

        private int _rental_id;

        public int Rental_id
        {
            get => _rental_id;
            set
            {
                _rental_id = value;
                OnPropertyChanged(nameof(Rental_id));
            }
        }

        private string _comment;

        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private int _rating;
        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }

        // для удаления комментария
        Review _selectedReview;
        public Review SelectedReview
        {
            get => _selectedReview;
            set
            {
                _selectedReview = value;
                OnPropertyChanged(nameof(SelectedReview));
            }
        }

        public SER_ViewModel()
        {
            _context = new();

            if (CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
            {
                Rentals = [.. _context.Rentals];
                Reviews = [.. _context.Reviews];
            }

            else
            {
                Reviews = [.. _context.Reviews.Where(x => x.Rental.UserId == CurrentUser.User.UserId)];
                Rentals = [.. _context.Rentals.Where(x => x.UserId == CurrentUser.User.UserId)];                
            }
        }

        public ICommand DeleteEntryCommand => new SER_RelayCommand(DeleteEntry, CanRemove);
        public ICommand AddCommentCommand => new SER_RelayCommand(AddComment, CanAddComment);
        public ICommand RemoveCommentCommand => new SER_RelayCommand(RemoveComment, CanRemoveComment);

        private void DeleteEntry(object? parameter)
        {
            // запрашиваем подтверждение на удаление
            var mb_result = MessageBox.Show("точно хотите удалить?", "", MessageBoxButton.YesNo);
            if(mb_result == MessageBoxResult.No)
                return;
            
            // удаляем и сохраняем изменения
            _context.Rentals.Remove(Selected);
            _context.SaveChanges();
            Rentals.Remove(Selected);
        }

        // метод проверки поля на соответствие
        private bool CanRemove(object? parameter) => Selected != null;


        private void AddComment(object? parameter)
        {
            Review review = new()
            {
                ReviewId = _context.Reviews.Any() ? _context.Reviews.Max(x => x.ReviewId) + 1 : 1,
                RentalId = Rental_id,
                Comment = Comment,
                Rating = Rating,
                ReviewDate = DateTime.Now                
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();
            Reviews.Add(review);


            if (CurrentUser.User.Role.Position.Equals("Администратор", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("добавленно");
                return;
            }

            MessageBox.Show("Спасибо за отзыв\nВы помогаете нам стать лучше");
        }

        bool CanAddComment(object? parameter) =>
            Rating > 0 && Rating < 6 && !string.IsNullOrEmpty(Comment);

        void RemoveComment(object? parameter)
        {
            _context.Reviews.Remove(SelectedReview);
            _context.SaveChanges();
            Reviews.Remove(SelectedReview);
        }

        bool CanRemoveComment(object? parameter) => SelectedReview != null;


        // метод для информирования системы об изменениях
        protected void OnPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    }
}