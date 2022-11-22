using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class User : INotifyPropertyChanged
    {
        private string name;
        private string company;
        public string Name { 
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
            get => name; }
        public string Company 
        { 
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
            get => company;
        }

        public User(string name = "", string company = "")
        {
            Name = name;
            Company = company;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
