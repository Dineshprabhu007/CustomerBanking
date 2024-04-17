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
            customer.Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {customer.Balance}");
        }

        public void Withdraw(Customer customer, double amount)
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

        public void CheckBalance(Customer customer)
        {
            Console.WriteLine($"Balance for {customer.Name}: {customer.Balance}");
        }
    }

}
