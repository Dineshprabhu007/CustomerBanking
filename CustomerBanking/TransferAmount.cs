using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking 
{
    public class TransferAmount : ITransferAmount
    {
        
        
        public void UPI(Customer customer)
        {
            try
            {
                Console.WriteLine("Enter the UPI ID:");
                string UPI = Console.ReadLine();
                if (string.IsNullOrEmpty(UPI))
                {
                    Console.WriteLine("Invalid UPI ID");
                    return;
                }
                else if (UPI.Length < 10)
                {
                    Console.WriteLine("Invalid UPI ID");
                    return;
                }
                Console.WriteLine("Enter the Amount to send:");
                if (!double.TryParse(Console.ReadLine(), out double transferAmount))
                {
                    Console.WriteLine("Invalid Transfer amount. Please enter a number.");
                    return;
                }
                if (transferAmount == 0.0d)
                {
                    Console.WriteLine("TransferAmount should not be zero");
                    return;
                }

                if (transferAmount < 0)
                {
                    Console.WriteLine(" Transfer amount cannot be negative.");
                    return;
                }

                if (transferAmount > customer.Balance)
                {
                    Console.WriteLine("Insufficient funds");
                    return;
                }
                Console.WriteLine($"Amount:{transferAmount} has been successfully sent to {UPI}");
                customer.Balance -= transferAmount;
                return;
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }

        }
        public void BankTransfer(Customer customer)
        {
            try
            {
                UserInputValidations userInputValidations = new UserInputValidations();
                Console.WriteLine("Enter Receiptent's account number:");
                string accountNumber = Console.ReadLine();
                if (!userInputValidations.IsNumeric(accountNumber))
                {
                    Console.WriteLine("Account Number should be Numeric");
                    return;
                }
                else if (accountNumber.Length > 20)
                {
                    Console.WriteLine("Invalid Account Number");
                    return;
                }
                else if (string.IsNullOrEmpty(accountNumber))
                {
                    Console.WriteLine("Invalid Account number");
                    return;
                }
                Console.WriteLine("Enter Receiptent's Name");
                string name = Console.ReadLine();
                if (!userInputValidations.IsCharacters(name))
                {
                    Console.WriteLine("Name should be alhabetic character only");
                    return;
                }
                else if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Empty value received,enter your name correctly");
                    return;
                }
                Console.WriteLine("Enter the Amount to send:");
                if (!double.TryParse(Console.ReadLine(), out double transferAmount))
                {
                    Console.WriteLine("Invalid Transfer amount. Please enter a number.");
                    return;
                }

                if (transferAmount < 0)
                {
                    Console.WriteLine(" Transfer amount cannot be negative.");
                    return;
                }

                if (transferAmount > customer.Balance)
                {
                    Console.WriteLine("Insufficient funds");
                    return;
                }
                if (transferAmount == 0.0d)
                {
                    Console.WriteLine("Zero amount can't be transfered");
                    return;
                }
                Console.WriteLine($"Amount {transferAmount} has been successfully sent to {name} ");
                customer.Balance -= transferAmount;
                return;
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }

        }
    }
}
