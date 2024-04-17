using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking
{
    public class CustomerService : ICustomerService
    {
        List<Customer> customers;
       
        public CustomerService()
        {
            customers = new List<Customer>();
            
        }

        public void AddCustomer(string accountNumber, string name, double initialDeposit, string mobileNumber, DateTime dob, string email)
        {
            customers.Add( new Customer(accountNumber, name, initialDeposit, mobileNumber, dob, email));
            Console.WriteLine("Customer added successfully!");
        }

        public Customer FindCustomerByMobileNumberAccountNumber(string mobileNumber,string accountNumber)
        {
            foreach (Customer customer in customers)
            {
                if (customer != null && customer.MobileNumber.Equals(mobileNumber) && customer.AccountNumber.Equals(accountNumber))
                {
                    return customer;
                }
            }
            return null;
        }
        public bool VerifyExistingAccount(string accountNumber) 
        {
            foreach(Customer customer in customers) 
            {
                if(customer.AccountNumber.Equals(accountNumber)) 
                { 
                    return true;
                }
                continue;
            }
            return false;
        }
        //public List<Customer> GetExistingAccountDetails()
        //{
        //    return customers;
        //}
    }
}
