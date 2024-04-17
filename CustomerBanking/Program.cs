using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking
{

    class Banking
    {
        static void Main(string[] args)
        {
            IBankService bankService = new BankService();
            try
            {
                while (true)
                {
                    Console.WriteLine("1. New Customer");
                    Console.WriteLine("2. Existing Customer");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("Enter your choice:");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            bankService.AddCustomer();
                            break;

                        case 2:
                            bankService.PerformOperations();
                            break;

                        case 3:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured:{ex.Message}"); }
        }
    }
}
