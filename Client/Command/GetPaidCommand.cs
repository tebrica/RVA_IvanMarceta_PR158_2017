using Client.ViewModel;
using Common.HomeBudgetPackage;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    internal class GetPaidCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            double s = MainViewModel.Service.GetSalary(double.Parse(parameter.ToString()),MainViewModel.user.House);
            if (s == -1011011000)
                return;
            BudgetViewModel.bvm.Budget = s;

        }
    }
}
