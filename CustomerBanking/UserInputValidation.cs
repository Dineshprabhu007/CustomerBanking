using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerBanking
{

    public  class UserInputValidations : IUserInputValidations
    {
        private static string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        //private List<Customer> customers;
        //private CustomerService customerService=new CustomerService();

        //public void GetExistingAccountDetails()
        //{
        //    customers=customerService.GetExistingAccountDetails();
        //}
        public bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsCharacters(string value)
        {
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool EmailValidation(string value)
        {
            if (!(Regex.IsMatch(value, pattern)))
            {
               
                return false;
            }
            else
            {
                return true;
            }
        }

        //public bool VerifyExistingAccount(string accountNumber)
        //{
        //    foreach (Customer customer in customers)
        //    {
        //        if (customer.AccountNumber.Equals(accountNumber))
        //        {
        //            return true;
        //        }
        //        continue;
        //    }
        //    return false;
        //}
    }
}
