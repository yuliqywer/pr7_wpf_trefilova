using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pr7_trefilova.Models
{
    public class CafeOrder :INotifyPropertyChanged
    {
        private string _dishName;
        private float _unitPrice;
        private int _quantity;
        private float _servicePercent;

        public string DishName
        {
            get => _dishName;
            set
            {
                if (_dishName != value)
                {
                    _dishName = value;
                    OnPropertyChanged( );
                }
            }
        }

        public float UnitPrice
        {
            get => _unitPrice;
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    OnPropertyChanged( );
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged( );
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public float ServicePercent
        {
            get => _servicePercent;
            set
            {
                if (_servicePercent != value)
                {
                    _servicePercent = value;
                    OnPropertyChanged( );
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public float TotalPrice
        {
            get
            {
                var subtotal = UnitPrice * Quantity;
                var serviceAmount = subtotal * (ServicePercent / 100f);
                return subtotal + serviceAmount;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
