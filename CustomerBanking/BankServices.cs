using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerBanking
{
    public class BankService : IBankService
    {
        private readonly ICustomerService customerService;
        private readonly IAccountService accountService;
        private readonly IUserInputValidations userInputValidations;
        public  ITransferAmount transferAmount;


        public BankService()
        {
            customerService = new CustomerService();
            accountService = new AccountService();
            userInputValidations = new UserInputValidations();
            transferAmount = new TransferAmount();

        }

        public void AddCustomer()
        {
            try
            {
                Console.WriteLine("Enter account number of 10 digit's only:");
                string accountNumber = Console.ReadLine();
                if (accountNumber.Length != 10 || !(userInputValidations.IsNumeric(accountNumber)))
                {
                    Console.WriteLine("Invalid account number.Account number should be numeric and must have 10 digit's.");
                    return;
                }
                else if (customerService.VerifyExistingAccount(accountNumber))
                {
                    Console.WriteLine("Account Number Already Exist.Try Different Combinations");
                    return;
                }

                Console.WriteLine("Enter customer name:");
                string name = Console.ReadLine();
                if (!(userInputValidations.IsCharacters(name)))
                {
                    Console.WriteLine("Name should not contain numeric characters");
                    return;
                }else if(string.IsNullOrEmpty(name)) 
                {
                    Console.WriteLine("Name should not be empty"); return;
                }

                Console.WriteLine("Enter initial deposit amount:");
                if (!double.TryParse(Console.ReadLine(), out double initialDeposit))
                {
                    Console.WriteLine("Invalid deposit amount. Please enter a number.");
                    return;
                }

                if (initialDeposit < 0)
                {
                    Console.WriteLine("Initial deposit amount cannot be negative.");
                    return;
                }
                if(initialDeposit > 100000)
                {
                    Console.WriteLine("Maximum Deposit Limit for your is 100000 at once.Try split deposit");
                    return;
                }

                Console.WriteLine("Enter 10-digit mobile number:");
                string mobileNumber = Console.ReadLine();
                if (mobileNumber.Length != 10 || !(userInputValidations.IsNumeric(mobileNumber)))
                {
                    Console.WriteLine("Invalid mobile number. Please enter a 10-digit numeric value.");
                    return;
                }


                Console.WriteLine("Enter date of birth (YYYY-MM-DD):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
                {
                    Console.WriteLine("Invalid date format. Please enter date in YYYY-MM-DD format.");
                    return;
                }

                Console.WriteLine("Enter email address:");
                //string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                string email = Console.ReadLine();
                if (!(userInputValidations.EmailValidation(email)))
                {
                    Console.WriteLine("Invalid Mail Format");
                    return;
                }



                customerService.AddCustomer(accountNumber, name, initialDeposit, mobileNumber, dob, email);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error accoured:{ex.Message}");
            }
        }

        public void PerformOperations()
        {
            try
            {
                Console.WriteLine("Enter 10-digit mobile number:");
                string mobileNumber = Console.ReadLine();
                Console.WriteLine("Enter 10-digit Account number");
                string accountNumber = Console.ReadLine();
                Customer existingCustomer = customerService.FindCustomerByMobileNumberAccountNumber(mobileNumber, accountNumber);
                if (existingCustomer != null)
                {
                    while (true)
                    {
                        Console.WriteLine("1. Deposit");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("3. Check Balance");
                        Console.WriteLine("4. Check My Details");
                        Console.WriteLine("5. TransferAmount");
                        Console.WriteLine("6. Exit");
                        Console.WriteLine("Enter your choice:");

                        if (!int.TryParse(Console.ReadLine(), out int option))
                        {
                            Console.WriteLine("Invalid option. Please enter a number.");
                            continue;
                        }

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter deposit amount:");
                                if (!double.TryParse(Console.ReadLine(), out double depositAmount))
                                {
                                    Console.WriteLine("Invalid deposit amount. Please enter a number.");
                                    continue;
                                }

                                if (depositAmount < 0)
                                {
                                    Console.WriteLine("Deposit amount cannot be negative.");
                                    continue;
                                }
                                if(depositAmount>100000)
                                {
                                    Console.WriteLine("Maximum deposit limit is 100000.Try Split deposit");
                                    continue;
                                }

                                accountService.Deposit(existingCustomer, depositAmount);
                                break;

                            case 2:
                                Console.WriteLine("Enter withdrawal amount:");
                                if (!double.TryParse(Console.ReadLine(), out double withdrawAmount))
                                {
                                    Console.WriteLine("Invalid withdrawal amount. Please enter a number.");
                                    continue;
                                }

                                if (withdrawAmount < 0)
                                {
                                    Console.WriteLine("Withdrawal amount cannot be negative.");
                                    continue;
                                }
                                if(withdrawAmount>50000)
                                {
                                    Console.WriteLine("Maximum Limit is 50000");
                                }

                                accountService.Withdraw(existingCustomer, withdrawAmount);
                                break;

                            case 3:
                                accountService.CheckBalance(existingCustomer);
                                break;

                            case 4:
                                accountService.GetAccountDetails(existingCustomer);
                                break;

                            case 5:
                                accountService.transferAmount(existingCustomer,transferAmount);
                                break;

                            case 6:
                                break;

                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }

                        if (option == 6)
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured:{ex.Message}");
            }
        }
        //check whether the string contains any alphabetic characters
        //private bool IsNumeric(string value)
        //{
        //    foreach (char c in value)
        //    {
        //        if (!char.IsDigit(c))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        //check whether the String has not any numbers
        //private bool IsCharacters(string value) 
        //{
        //    foreach (char c in value)
        //    {
        //        if (char.IsDigit(c))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
