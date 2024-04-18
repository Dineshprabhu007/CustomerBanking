using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking
{
    public class Customer
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        //public Customer(string accountNumber, string name, double initialDeposit, string mobileNumber, DateTime dob, string email)
        //{
        //    this.AccountNumber = accountNumber;
        //    this.Name = name;
        //    this.Balance = initialDeposit;
        //    this.MobileNumber = mobileNumber;
        //    this.DateOfBirth = dob;
        //    this.Email = email;
        //}
    }
}
