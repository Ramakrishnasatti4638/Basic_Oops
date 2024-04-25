using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank
{
    public enum Gender {Select, Male, Female} 
    public class CustomerDetails
    {
        private static int s_customerID=1000;
        public string CustomerID { get;  }
        public string CustomerName { get; set; }
        public long Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public DateTime DOB { get; set; }



        public CustomerDetails(string customerName,long balance, Gender gender, long phone, string mailID, DateTime dob)
        {
            s_customerID++;
            CustomerID+="HDFC"+s_customerID;
            CustomerName=customerName;
            Balance=balance;
            Gender=gender;
            Phone=phone;
            MailID=mailID;
            DOB=dob;
        }

        public void Deposit(long amount)
        {
            long balanceAfterDeposit=amount+Balance;
            Balance=balanceAfterDeposit;
            System.Console.WriteLine("Deposit successfull. Current balance "+Balance);
        }

        public void WithDraw(long amount)
        {
            if(amount>Balance)
            {
                System.Console.WriteLine("Insufficient balance");
                
            }
            else
            {
                long balanceAfterWithdraw=Balance-amount;
                Balance=balanceAfterWithdraw;
                System.Console.WriteLine("Withdraw successfull. Current balance "+Balance);
            }
        }
    }
}