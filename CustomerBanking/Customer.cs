using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking
{
    public class Customer
    {
        public string AccountNumber { get; }
        public string Name { get; }
        public double Balance { get; set; }
        public string MobileNumber { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }

        public Customer(string accountNumber, string name, double initialDeposit, string mobileNumber, DateTime dob, string email)
        {
            this.AccountNumber = accountNumber;
            this.Name = name;
            this.Balance = initialDeposit;
            this.MobileNumber = mobileNumber;
            this.DateOfBirth = dob;
            this.Email = email;
        }
    }
}
