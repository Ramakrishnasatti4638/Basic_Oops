using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
        private static int s_customerID=1000;
        public string CustomerID { get;  }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerNumber { get; set; }
        public double CustomerWalletBalance { get; set; }
        public string CustomerEmailID { get; set; }

        public CustomerDetails(string customerID,string customerName,string customerCity,string customerNumber,double customerWalletBalance,string customerEmailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            CustomerName=customerName;
            CustomerCity=customerCity;
            CustomerNumber=customerNumber;
            CustomerWalletBalance=customerWalletBalance;
            CustomerEmailID=customerEmailID;
        }

        public  void DeductAmount(double amount)
        {
            CustomerWalletBalance-=amount;
        }

        public void WalletRecharge()
        {
            System.Console.WriteLine("Enter the amount to recharge: ");
            double amount=double.Parse(Console.ReadLine());
            CustomerWalletBalance+=amount;
            System.Console.WriteLine("Your wallet balance is: "+CustomerWalletBalance);
        }
    }
}