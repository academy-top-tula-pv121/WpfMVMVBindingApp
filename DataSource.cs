using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class DataSource : INotifyPropertyChanged
    {
        private User userSelect;

        public User UserSelect
        {
            set
            {
                userSelect = value;
                OnPropertyChanged(nameof(UserSelect));
            }
            get => userSelect;
        }
        public ObservableCollection<User> Users { set; get; }
        public DataSource()
        {
            Users = new ObservableCollection<User>
            {
                new User("Bob", "Yandex"),
                new User("Tim", "Mail Group"),
                new User("Sam", "Ozon"),
                new User("Joe", "Yandex")
            };
                
        }
       
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
