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
            try
            {
                customers = new List<Customer>();
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }

        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                customers.Add((customer));
                Console.WriteLine("Customer added successfully!");
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }

        public Customer FindCustomerByMobileNumberAccountNumber(string mobileNumber,string accountNumber)
        {
            try
            {
                foreach (Customer customer in customers)
                {
                    if (customer != null && customer.MobileNumber.Equals(mobileNumber) && customer.AccountNumber.Equals(accountNumber))
                    {
                        return customer;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
            return null;

        }
        public bool VerifyExistingAccount(string accountNumber) 
        {
            try
            {
                foreach (Customer customer in customers)
                {
                    if (customer.AccountNumber.Equals(accountNumber))
                    {
                        return true;
                    }
                    continue;
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
            return false;
        }
        //public List<Customer> GetExistingAccountDetails()
        //{
        //    return customers;
        //}
    }
}
