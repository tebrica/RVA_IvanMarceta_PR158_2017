using Client.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public MainViewModel mvm { get; set; }
        public LoginViewModel lvm { get; set; }
        private string username;
        public string Username
        {
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
        public ICommand RegisterPageCommand { get; }
        public ICommand LoginCommand { get; }
        public LoginViewModel(MainViewModel mvm)
        {
            lvm = this;
            this.mvm = mvm;
            RegisterPageCommand = new RegisterPageCommand();
            LoginCommand = new LoginCommand();
        }
    }
}
