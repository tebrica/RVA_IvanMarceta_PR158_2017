using Common.HomeBudgetPackage;
using Common.Model;
using Common.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Database
    {
        private static Dictionary<Category, InvokerSubjectContext> database = new Dictionary<Category, InvokerSubjectContext>();
        private static Dictionary<string,User> Users = new Dictionary<string, User>();

        public static InvokerSubjectContext getNode(Category category) 
        {
            try
            {
                return database[category];
            }
            catch
            {
                return null;
            }
        }
        public static Category getBudget(string name)
        {
            return database.Keys.First(x => x.name.Equals(name));
        }
        public static Category getBudget(User user)
        {
            try
            {
                Category c = database.Keys.First(x => x.name.Equals(user.House));
                return c;
            }
            catch
            {
                newNode(
                        new Category(new Entry("description", user.Salary), user.House),
                        new InvokerSubjectContext(
                            user.Salary,
                            user.House,
                            new UseBudgetCommand(
                                new Budget(user.Salary, user.House),
                                user.Salary)
                            )
                    );
            }
            Category category = database.Keys.First(x => x.name.Equals(user.House));
            return category;
        }
        public static void newNode(Category category, InvokerSubjectContext household)
        {
            database.Add(category, household);
        }
        public static void deleteNode(Category category) 
        {
            database.Remove(category);
        }
        public static void updateNode(Category category, InvokerSubjectContext household)
        {
            deleteNode(category);
            newNode(category, household);
        }
        public static User getUser(string userName)
        {
            try
            {
                return Users[userName];
            }
            catch
            {
                return null;
            }
        }
        public static void newUser(User user)
        {
            Users.Add(user.UserName, user);
        }
        public static void deleteUser(string userName)
        {
            Users.Remove(userName);
        }
        public static void updateUser(User user)
        {
            deleteUser(user.UserName);
            newUser(user);
        }
        public static void FillInTheData()
        {
            User user1 = new User("sad", "sad", userType.NORMAL, "sad",20000);
            User user2 = new User("qwe", "qwe", userType.NORMAL, "qwe", 20000);
            User user3 = new User("zxc", "zxc", userType.NORMAL, "zxc", 20000);
            User user4 = new User("admin", "admin", userType.ADMIN, "admin", 20000);
            newUser(user1);
            newUser(user2);
            newUser(user3);
            newUser(user4);
        }
    }
}
