using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    internal class LogoutCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            (parameter as MainViewModel).update(new LoginViewModel(parameter as MainViewModel));
        }
    }
}
