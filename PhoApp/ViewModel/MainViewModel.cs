using PhoApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PhoApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Orders = new ObservableCollection<Phone>();
            Phones = GetPhones();
        }
        public int OrderCount => Orders.Count;

        public float TotalPrice => Orders.Sum(x => x.Price);

        private ObservableCollection<Phone> phones;

        public ObservableCollection<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Phone> orders;
        public ObservableCollection<Phone> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private ObservableCollection<Phone> GetPhones()
        {
            return new ObservableCollection<Phone>
            {
                new Phone{ Name = "Iphone 11 Purple", Image = "phone1.png", Price = 659f, Description = "Об'єм пам'яті 64GB, Роздільна здатність дисплея 2532x1170,Акумулятор 2775 mAh"},
                new Phone{ Name = "Iphone 12 Red", Image = "phone2.png", Price = 759f, Description ="Об'єм пам'яті 128GB, Роздільна здатність дисплея 2532x1170,Акумулятор 3775 mAh"},
                new Phone{ Name = "Iphone 12 Blue", Image = "phone3.png", Price = 790f, Description ="Об'єм пам'яті 256GB, Роздільна здатність дисплея 2532x1170,Акумулятор 3775 mAh"},
                new Phone{ Name = "Iphone 14 Gold", Image = "phone4.png", Price = 2299f, Description ="Об'єм пам'яті 514GB, Роздільна здатність дисплея 2532x1170,Акумулятор 4200 mAh"},
                new Phone{ Name = "Iphone 14 Black Purple", Image = "phone5.png", Price = 1890f, Description ="Об'єм пам'яті 514GB, Роздільна здатність дисплея 2532x1170,Акумулятор 4200 mAh"},
            };
        }

        public void AddOrder(Phone item)
        {
            if (item != null)
            {
                Orders.Add(item);
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));

            }
        }

    }
}
