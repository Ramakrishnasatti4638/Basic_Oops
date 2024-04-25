using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{

    /// <summary>
    /// 
    /// enum methods for Gender and Deaprtment
    /// 
    /// </summary>
    public enum Gender{Select,Male,Female}
    public enum Department{ECE,EEE,CSE}

    /// <summary>
    /// 
    /// class to store the user details
    /// 
    /// </summary>
    public class UserDetails
    {
        /*
            a.	UserID (Auto Increment – SF3000)
            b.	UserName
            c.	Gender
            d.	Department – (Enum – ECE, EEE, CSE)
            e.	MobileNumber
            f.	MailID

        */

        //Static field
        private static int s_userID=3000;

        //propperties
        public string UserId { get; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }

        //Constructor

        /// <summary>
        /// Default constructor for <see cref="UserDetails"/>\
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="gender"></param>
        /// <param name="department"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="mailID"></param>
        /// <param name="walletBalance"></param>
        public UserDetails(string userName,Gender gender,Department department,string mobileNumber,string mailID,double walletBalance)
        {
            s_userID++;
            UserId="SF"+s_userID;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }

        //Methods
        /// <summary>
        /// Wallet recharge method to recharge the wallet <see cref="UserDetails"/>
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double WalletRecharge(double amount)
        {
            WalletBalance+=amount;
            return WalletBalance;
        }


        /// <summary>
        /// Deduct Amount constructor to deduct amount from wallet <see cref="UserDetails"/>
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double DeductAmount(double amount)
        {
            if(amount>WalletBalance)
            {
                Console.WriteLine("Insufficient balance please recharge first.");
                return 0;
            }
            else
            {
                return WalletBalance-=amount;
            }
        }
    }
}