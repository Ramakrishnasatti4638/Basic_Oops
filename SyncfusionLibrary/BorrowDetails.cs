using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    public enum Status{Default, Borrowed, Returned}

    /// <summary>
    /// Borrow Details to store the borrowed book details <see cref="BorrowDetails"/>
    /// </summary>
    public class BorrowDetails
    {
        /*
        •	BorrowID (Auto Increment – LB2000)
        •	BookID 
        •	UserID
        •	BorrowedDate – ( Current Date and Time )
        •	BorrowBookCount 
        •	Status –  ( Enum - Default, Borrowed, Returned )
        •	PaidFineAmount

        */

        //static field
        private static int s_borrowID=2000;

        //properties
        public string BorrowID { get; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowBookCount { get; set; }
        public Status Status { get; set; }
        public double PaidFineAmount { get; set; }

        /// <summary>
        /// Constructor for <see cref="BorrowDetails"/>
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="userID"></param>
        /// <param name="borrowedDate"></param>
        /// <param name="borrowBookCount"></param>
        /// <param name="status"></param>
        /// <param name="paidFineAmount"></param>
        public BorrowDetails(string bookID,string userID,DateTime  borrowedDate,int borrowBookCount,Status status,double paidFineAmount)
        {
            s_borrowID++;
            BorrowID="LB"+s_borrowID;
            BookID=bookID;
            UserID=userID;
            BorrowedDate=borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFineAmount;
        }
    }
}