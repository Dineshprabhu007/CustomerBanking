﻿using System;
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
        void AddCustomer(string accountNumber, string name, double initialDeposit, string mobileNumber, DateTime dob, string email);
        Customer FindCustomerByMobileNumber(string mobileNumber);
        bool VerifyExistingAccount(string accountNumber);
    }

    public interface IAccountService
    {
        void Deposit(Customer customer, double amount);
        void Withdraw(Customer customer, double amount);
        void CheckBalance(Customer customer);
    }

    public interface IUserInputValidations
    {
         bool IsNumeric(string value);
         bool IsCharacters(string value);
         //void GetExistingAccountDetails();
         //bool VerifyExistingAccount(string accountNumber);
         bool EmailValidation(string value);


    }
}