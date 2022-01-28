using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.HomeBudgetPackage;
using Common.Model;
using Common.Patterns;

namespace Server
{
    public class ServiceHandler : IService
    {
        public double PayBills(double amount,string house)
        {
            InvokerSubjectContext isc = Database.getNode(Database.getBudget(house));
            if (isc is null)
                return -1011011000;
            if (isc.State is NetNegativeState)
                return -1011011000;
            try
            {
                Command c = isc.Command.Find(x => (x as Command).Amount.Equals(amount) && x is UseBudgetCommand);
                if (c is null)
                    throw (new Exception());
                double ret = isc.ExecuteCommand(c);
                if (ret == -1011011000)
                    throw (new Exception());
                return ret;
            }
            catch
            {
                if (isc.Command.Count != 0)
                {
                    Command newCommand = new UseBudgetCommand((isc.Command[0] as Command).Budget, amount);
                    isc.SetCommand(newCommand);
                    return isc.ExecuteCommand(newCommand);
                }
                else
                {
                    return -1011011000;
                }
            }
        }
        public double GetSalary(double amount, string house)
        {
            InvokerSubjectContext isc = Database.getNode(Database.getBudget(house));
            try
            {
                Command c = isc.Command.Find(x => (x as Command).Amount.Equals(amount) && x is GetSalaryCommand);
                if (c is null)
                    throw (new Exception());
                double ret = isc.ExecuteCommand(c);
                if (ret == -1011011000)
                    throw(new Exception());
                return ret;
            }
            catch
            {
                if (isc.Command.Count != 0)
                {
                    Command newCommand = new GetSalaryCommand((isc.Command[0] as Command).Budget, amount);
                    isc.SetCommand(newCommand);
                    return isc.ExecuteCommand(newCommand);
                }
                else
                {
                    return -1011011000;
                }
            }
        }
        public double Undo(Category category)
        {
            InvokerSubjectContext isc = Database.getNode(category);
            return isc.UnexecuteCommand(isc.Command.Find(x => (x as UseBudgetCommand).Amount.Equals(category.GetAmount())));
        }
        public bool NewHouse(double budget, Category category)
        {
            if (Database.getNode(category) != null)
                return false;
            InvokerSubjectContext isc = new InvokerSubjectContext(budget,category.GetName(), new UseBudgetCommand(new Budget(budget, category.GetName()),100));
            Database.newNode(category, isc);
            return true;
        }
        public User Login(string username, string password)
        {
           if(Database.getUser(username) != null)
            {
                if(Database.getUser(username).Password == password)
                {
                    User user = Database.getUser(username);
                    Database.getBudget(user);
                    return user;
                }
            }
            return null;
        }
        public double GetBudget(string house)
        {
            var ret = Database.getBudget(house);
            if (ret != null)
                return ret.m_Entry.value;
            return -1011011000;
        }
        public Category GetCategory(string house)
        {
            return Database.getBudget(house);
        }
        public bool Register(User user)
        {
            if (Database.getUser(user.UserName) != null)
                return false;
            Database.newUser(user);
            return true;
        }
    }
}
