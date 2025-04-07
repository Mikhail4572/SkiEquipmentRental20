using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using SkiEquipmentRental20.Classes;
using SkiEquipmentRental20.Models;

namespace SkiEquipmentRental20.ViewModels
{
    class EquipmentEditViewModel : INotifyPropertyChanged
    {
        // реализация наследуемого интерфейса INotifyPropertyChanged для контроля изменения полей и свойств
        public event PropertyChangedEventHandler? PropertyChanged;

        private SkiRentalDBContext _context;
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

        private ObservableCollection<Status> _statuses;

        public ObservableCollection<Status> Statuses
        {
            get => _statuses;
            set
            {
                _statuses = value;
                OnPropertyChanged(nameof(Statuses));
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

        private int _equipmentId;
        public int EquipmentId 
        {
            get => _equipmentId;
            set
            {
                _equipmentId = value;
                OnPropertyChanged(nameof(EquipmentId));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private Status? _selected_status = null;
        public Status? Selected_status
        {
            get => _selected_status;
            set
            {
                _selected_status = value;
                OnPropertyChanged(nameof(Selected_status));
            } 
        }

        public EquipmentEditViewModel(Equipment selected)
        {
            _context = new();
            this.Selected = selected;
            Statuses = [.. _context.Statuses];
            CurrentCommand = new SER_RelayCommand(EditEquipment, CanEdit);
        }

        public EquipmentEditViewModel()
        {
            _context = new();
            Equipments = [.. _context.Equipment];
            Statuses = [.. _context.Statuses];
            CurrentCommand = new SER_RelayCommand(AddEquipment, CanAdd);
        }

        public ICommand EquipmentRemoveCommand => new SER_RelayCommand(RemoveEquipment, CanRemove);
        public ICommand EquipmentRestoreCommand => new SER_RelayCommand(RestoreEquipment, CanRemove);
       
        private ICommand _currentCommand;
        public ICommand CurrentCommand
        {
            get => _currentCommand;
            set
            {
                _currentCommand = value;
                OnPropertyChanged(nameof(CurrentCommand));
            }
        }


        private void AddEquipment(object? parameter)
        {
            Equipment equipment = new();

            int? equipment_id = null;

            if (_context.Equipment.Any())
                equipment_id = _context.Equipment.Max(x => x.EquipmentId) + 1;

            else
                equipment_id = 1;

            equipment.EquipmentId = (int)equipment_id;
            equipment.Name = Name;
            equipment.Type = Type;
            equipment.Price = Price;
            equipment.Quantity = Quantity;
            equipment.StatusId = Selected_status.StatusId;
            equipment.Isdelited = false;

            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            MessageBox.Show("Успешно");
        }

        private bool CanAdd(object? parameter) => !string.IsNullOrEmpty(Name) 
            && !string.IsNullOrEmpty(Type) && Price > 0 && Quantity > 0
            && Selected_status != null;

        private void RemoveEquipment(object? parameter)
        {
            var res = _context.Equipment.FirstOrDefault(x => x.EquipmentId == Selected.EquipmentId);
            res.Isdelited = true;
            Selected = null;
            Equipments = [.. _context.Equipment];
            _context.SaveChanges();
            MessageBox.Show("Успешно");
        }
        
        private void RestoreEquipment(object? parameter)
        {
            var res = _context.Equipment.FirstOrDefault(x => x.EquipmentId == Selected.EquipmentId);
            res.Isdelited = false;
            Selected = null;
            Equipments = [.. _context.Equipment];
            _context.SaveChanges();
        }

        private bool CanRemove(object? parameter) =>
            Selected != null && Selected.Isdelited;

        private void EditEquipment(object? parameter)
        {           
            var edit_equipment = _context.Equipment.FirstOrDefault(x => x.EquipmentId == EquipmentId);

            edit_equipment.Name = Name;
            edit_equipment.Price = Price;
            edit_equipment.Quantity = Quantity;
            edit_equipment.StatusId = Selected_status.StatusId;
            edit_equipment.Type = Type;
            _context.SaveChanges();

            Name = "";
            Price = 0;
            Quantity = 0;
            Selected_status = null;
            Type = "";
            MessageBox.Show("изменено");
        }

        private bool CanEdit(object? parameter) => 
            !string.IsNullOrEmpty(Name) && Price > 0 && Quantity > 0 
            && Selected_status != null && !string.IsNullOrEmpty(Type);

        protected void OnPropertyChanged(string property)
        {
            if (property == nameof(Selected))
            {
                if (Selected != null)
                {
                    EquipmentId = Selected.EquipmentId;
                    Name = Selected.Name;
                    Price = Selected.Price;
                    Quantity = Selected.Quantity;
                    Selected_status = Selected.Status;
                    Type = Selected.Type;
                }
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}