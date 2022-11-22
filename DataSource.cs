using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    internal class DataSource : INotifyPropertyChanged
    {
        // User
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

        // User Collection
        public ObservableCollection<User> Users { set; get; }

        // Commands
        // Add
        private MyCommand? addCommand;
        public MyCommand? AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new MyCommand(
                    obj =>
                    {
                        User user = new User();
                        Users.Insert(0, user);
                        UserSelect = user;
                    }
                    ));
            }
        }

        // Delete
        private MyCommand? removeCommand;
        public MyCommand? RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new MyCommand(
                        obj =>
                        {
                            if(obj is User user)
                            {
                                Users.Remove(user);
                            }
                                
                        },
                        (obj) => Users.Count > 0 && (User)obj is not null
                    ));
            }
        }
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
