using Common;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public static User user;
        public ViewModelBase CurrentViewModel { get; set; }
        private MainWindow mw;
        public static IService Service { get; set; }
        public MainViewModel(MainWindow mw)
        {
            Connection();
            this.mw = mw;
            CurrentViewModel = new RegisterViewModel(this);
        }
        public void update(ViewModelBase vmb)
        {
            CurrentViewModel = vmb;
            ViewModelChanged();
        }
        private void ViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void Connection()
        {
            var myBinding = new NetTcpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("net.tcp://localhost:53673/");
            ChannelFactory<IService> factory = new ChannelFactory<IService>(myBinding, myEndpoint);

            Service = factory.CreateChannel();
        }
    }
}
