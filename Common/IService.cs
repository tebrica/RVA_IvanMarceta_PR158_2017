using Common.HomeBudgetPackage;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace Common
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        double PayBills(double amount, string house);
        [OperationContract]
        double GetSalary(double amount, string house);
        [OperationContract]
        double Undo(Category category);
        [OperationContract]
        bool NewHouse(double budget, Category category);
        [OperationContract]
        User Login(string username, string password);
        [OperationContract]
        bool Register(User user);
        [OperationContract]
        double GetBudget(string house);
        [OperationContract]
        Category GetCategory(string house);
    }
}
