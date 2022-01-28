using Client.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public MainViewModel mvm { get; set; }
        public RegisterViewModel rvm { get; set; }
        private string username;
        public string Username { 
            get 
            { 
                return username; 
            } 
            set 
            { 
                username = value; OnPropertyChanged(nameof(Username)); 
            } 
        }
        private string password;
        public string Password { get { return password; } set { password = value; OnPropertyChanged(nameof(Password)); } }
        private string house;
        public string House { get { return house; } set { house = value; OnPropertyChanged(nameof(House)); } }
        private string userType;
        public string UserType { get { return userType; } set { userType = value; OnPropertyChanged(nameof(UserType)); } }
        private double salary;
        public double Salary { get { return salary; } set { salary = value; OnPropertyChanged(nameof(Salary)); } }

        public ICommand RegisterCommand { get; }
        public ICommand LoginPageCommand { get; }
        public RegisterViewModel(MainViewModel mvm)
        {
            rvm = this;
            this.mvm = mvm;
            RegisterCommand = new RegisterCommand();
            LoginPageCommand = new LoginPageCommand();
        }
    }
}
