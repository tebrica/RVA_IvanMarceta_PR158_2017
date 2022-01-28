using Client.Command;
using Common.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModel
{
    internal class BudgetViewModel : ViewModelBase
    {
        public static BudgetViewModel bvm;
        public MainViewModel mvm { get; set; }
        public ICommand LogoutCommand { get; }
        private double info;
        public double Info { get { return info; } set { info = value; OnPropertyChanged(nameof(info)); } }
        private double internet;
        public double Internet { get { return internet; } set { internet = value; OnPropertyChanged(nameof(Internet)); } }
        private double mobile;
        public double Mobile { get { return mobile; } set { mobile = value; OnPropertyChanged(nameof(Mobile)); } }
        private double salary;
        public double Salary { get { return salary; } set { salary = value; OnPropertyChanged(nameof(Salary)); } }
        private double budget;
        public double Budget { get { return budget; } set { budget = value; OnPropertyChanged(nameof(Budget)); } }
        public BudgetViewModel(MainViewModel mvm, double budget, double salary)
        {
            bvm = this;
            this.LogoutCommand = new LogoutCommand();
            this.mvm = mvm;
            Random rnd = new Random();
            info = rnd.Next(10000, 20000);
            internet = rnd.Next(1500, 2000);
            mobile = rnd.Next(700, 5000);
            this.budget = budget;
            this.salary = salary;
            PayCommand = new PayCommand();
            GetPaidCommand = new GetPaidCommand();
        }
        public ICommand PayCommand { get; }
        public ICommand GetPaidCommand { get; }
    }
}
