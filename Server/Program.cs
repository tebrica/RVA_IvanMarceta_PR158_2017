using Common;
using System;
using System.ServiceModel;
namespace Server
{
    public class Server
    {
        static void Main(string[] args)
        {
            Database.FillInTheData();
            var myBinding = new NetTcpBinding();
            Uri myEndpoint = new Uri("net.tcp://localhost:53673/");
            ServiceHost serviceHost = new ServiceHost(typeof(ServiceHandler), myEndpoint);
            serviceHost.Open();
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}