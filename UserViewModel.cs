using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp1
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private User user;
        public UserViewModel(User user)
        {
            this.user = user;
        }

        public string UserName
        {
            get => user.Name;
            set
            {
                user.Name = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string UserCompany
        {
            get => user.Company;
            set
            {
                user.Company = value;
                OnPropertyChanged(nameof(UserCompany));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
