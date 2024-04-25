using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    /// <summary>
    /// Book details class to store the book details <see cref="BookDetails"/>
    /// </summary>
    public class BookDetails
    {
        /*
        1.	BookID (Auto Increment - BID1000)
        2.	BookName
        3.	AuthorName
        4.	BookCount

        */

        //static field
        private static int s_bookID=1000;

        //properties
        public string BookID { get; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int  BookCount { get; set; }

        //Constructor
        /// <summary>
        /// Constructor for <see cref="BookDetails"/>
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="authorName"></param>
        /// <param name="bookCount"></param>
        public BookDetails(string bookName,string authorName,int bookCount)
        {
            s_bookID++;
            BookID="BID"+s_bookID;
            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;
        }


    }
}