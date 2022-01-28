using Client.ViewModel;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    internal class LoginCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            User user = MainViewModel.Service.Login((parameter as LoginViewModel).Username, (parameter as LoginViewModel).Password);
            if (user is not null)
            {
                (parameter as LoginViewModel).mvm.update(
                    new BudgetViewModel((parameter as LoginViewModel).mvm,
                    MainViewModel.Service.GetBudget(user.House),
                    user.Salary));
            }
            MainViewModel.user = user;
        }
    }
}
