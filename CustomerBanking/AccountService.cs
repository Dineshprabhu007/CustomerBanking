using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking
{
    public class AccountService : IAccountService
    {
        public void Deposit(Customer customer, double amount)
        {
            try
            {
                customer.Balance += amount;
                Console.WriteLine($"Deposited {amount}. New balance: {customer.Balance}");
            }
            catch(Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }

        public void Withdraw(Customer customer, double amount)
        {
            try
            {
                if (amount <= customer.Balance)
                {
                    customer.Balance -= amount;
                    Console.WriteLine($"Withdrawn {amount}. New balance: {customer.Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }

        public void CheckBalance(Customer customer)
        {
            try
            {
                Console.WriteLine($"Balance for {customer.Name}: {customer.Balance}");
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }
    }

}
