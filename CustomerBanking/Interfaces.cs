using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBanking
{
    public interface IBankService
    {
        void AddCustomer();
        void PerformOperations();
    }

    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        Customer FindCustomerByMobileNumberAccountNumber(string mobileNumber,string accountNumber);
        bool VerifyExistingAccount(string accountNumber);
    }

    public interface IAccountService
    {
        void Deposit(Customer customer, double amount);
        void Withdraw(Customer customer, double amount);
        void CheckBalance(Customer customer);
        void GetAccountDetails(Customer customer);
        void transferAmount(Customer customer,ITransferAmount transferAmount);
        
    }

    public interface IUserInputValidations
    {
         bool IsNumeric(string value);
         bool IsCharacters(string value);
         //void GetExistingAccountDetails();
         //bool VerifyExistingAccount(string accountNumber);
         bool EmailValidation(string value);


    }
    public interface ITransferAmount
    {
        void UPI(Customer customer);
        void BankTransfer(Customer customer);
       
    }
}
