using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkiEquipmentRental20.Classes
{
    class SER_RelayCommand : ICommand
    {
        // действие
        private readonly Action<object> _execute;
        // проверка на возможность его совершения
        private readonly Func<object, bool>? _canExecute;

        // конструктор
        public SER_RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            // проверяем не null ли execute, если да то, отображаем исключение и передаём название свойства 
            // вызывавшего исключение
            // если нет то, передаём принимаемый параметр в поле
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // создаём очередь команд        
        public event EventHandler? CanExecuteChanged
        {
            // если поступила то, добавляем в очередь
            add => CommandManager.RequerySuggested += value;
            // если выполнена или отменена то, убераем из очереди
            remove => CommandManager.RequerySuggested -= value;
        }

        // проверяем возможно ли действие и если да то, выполняем
        public bool CanExecute(object? parameter) =>
            _canExecute == null || _canExecute(parameter);

        // выполняем действие
        public void Execute(object? parameter) =>
            _execute(parameter);
    }
}
