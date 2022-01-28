using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public enum userType{
        ADMIN,NORMAL
    };
    [DataContract]
    public class User
    {
        [DataMember]
        private string userName;
        [DataMember]
        private string password;
        [DataMember]
        private userType userType;
        [DataMember]
        private string house;
        [DataMember]
        private double salary;

        public User(string userName, string password, userType userType, string house, double salary)
        {
            this.userName = userName;
            this.password = password;
            this.userType = userType;
            this.House = house;
            this.salary = salary;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public userType UserType { get => userType; set => userType = value; }
        public string House { get => house; set => house = value; }
        public double Salary { get => salary; set => salary = value; }
    }
}
