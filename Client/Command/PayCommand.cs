using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    internal class PayCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            double s = MainViewModel.Service.PayBills(double.Parse(parameter.ToString()), MainViewModel.user.House);
            if (s == -1011011000)
                return;
            BudgetViewModel.bvm.Budget = s;

        }
    }
}
