using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Account
    {
        //FIELDS
        private decimal accountBalance;
        private DateTime time = new DateTime();

        //PROPERTIES
        public decimal AccountBalance { get; set; }
        public DateTime Time { get; set; }

        //METHODS
        public void Withdraw(decimal amount)
        {
            this.AccountBalance -= amount;
            this.Time = DateTime.Now;
        }
        public void Deposit(decimal amount)
        {
            this.AccountBalance += amount;
            this.Time = DateTime.Now;
        }
        public decimal OverdraftChecker(decimal amount)     //returns the amount that will be withdrawn from the account
        {
            if (amount <= this.AccountBalance)  //if user wants to withdraw a valid amount
            {
                return amount;
            }
            else         //user wants to withdraw more than amount in the account
            {
                Console.WriteLine("Transaction cancelled. Insufficient funds.");
                return 0.00M;
            }
        }

        //CONSTRUCTOR
        public Account()
        {
            this.AccountBalance = 100.00M;
        }
    }
}
