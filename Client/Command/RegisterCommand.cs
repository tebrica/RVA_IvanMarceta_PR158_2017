using Client.ViewModel;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    internal class RegisterCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            try
            {
                if ((parameter as RegisterViewModel).House.Equals("") ||
                    (parameter as RegisterViewModel).UserType.Equals("") ||
                    (parameter as RegisterViewModel).Username.Equals("") ||
                    (parameter as RegisterViewModel).Password.Equals("")
                    )
                {
                    return;
                }
            }
            catch
            {
                return;
            }
            userType ut;
            if((parameter as RegisterViewModel).UserType.Equals("Admin"))
            {
                ut = userType.ADMIN;
            }
            else
            {
                ut = userType.NORMAL;
            }
            User user = new User(
                (parameter as RegisterViewModel).Username,
                (parameter as RegisterViewModel).Password,
                ut,
                (parameter as RegisterViewModel).House,
                (parameter as RegisterViewModel).Salary
            );

            if (MainViewModel.Service.Register(user))
            {
                MainViewModel.Service.NewHouse(
                    (parameter as RegisterViewModel).Salary, 
                    new Common.HomeBudgetPackage.Category(
                        new Common.HomeBudgetPackage.Entry(
                                "description", 
                                (parameter as RegisterViewModel).Salary
                            ),
                        (parameter as RegisterViewModel).House
                        )
                    );
                (parameter as RegisterViewModel).mvm.update(
                    new BudgetViewModel((parameter as RegisterViewModel).mvm,
                    MainViewModel.Service.GetBudget((parameter as RegisterViewModel).House), 
                    (parameter as RegisterViewModel).Salary)
                );
            }
            MainViewModel.user = user;
        }
    }
}
