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
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
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

        public void GetAccountDetails(Customer customer)
        {
            try
            {
                Console.WriteLine($" Account Number:{customer.AccountNumber} \n Name:{customer.Name} " +
                    $"\n Mobile Number:{customer.MobileNumber} \n Date of Birth:{customer.DateOfBirth} \n Email:{customer.Email}");
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }

        public void transferAmount(Customer customer, ITransferAmount transferAmount)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Select the transfer method:");
                    Console.WriteLine("1. UPI");
                    Console.WriteLine("2. BankTransfer");
                    Console.WriteLine("3. Exit");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        continue;
                    }
                    switch (choice)
                    {
                        case 1:
                            transferAmount.UPI(customer);
                            break;
                        case 2:
                            transferAmount.BankTransfer(customer);
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;

                    }
                    if (choice == 3)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }
    }

}
