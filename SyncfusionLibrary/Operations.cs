using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    /// <summary>
    /// class to do all the operations <see cref="Operations"/>
    /// </summary>
    public static class Operations
    {

        //local/global object
        static UserDetails currentLoggedInUser;
        //static lists
        static List<UserDetails> userList = new List<UserDetails>();
        static List<BookDetails> bookList = new List<BookDetails>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();

        /// <summary>
        /// Main menu for displaying the details <see cref="Operations"/>
        /// </summary>
        public static void MainMenu()
        {
            Console.WriteLine("**************************Welcome to Syncfusion Library**************************");
            string mainChoice = "yes";
            do
            {
                //display menu
                Console.WriteLine("Main Menu\n1. User Registration\n2. User Login\n3. Exit");
                Console.Write("Enter the option number form the above: ");
                //get input form user
                int menuOption;
                bool temp = int.TryParse(Console.ReadLine(), null, out menuOption);
                while (!temp)
                {
                    Console.WriteLine("Invalid input. Please try again");
                    temp = int.TryParse(Console.ReadLine(), null, out menuOption);
                }
                //iterate the menu from the user input
                switch (menuOption)
                {
                    case 1:
                        {
                            Console.WriteLine("***********************User Registration***********************");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***********************User Login***********************");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Closing the Application");
                            mainChoice = "no";
                            break;
                        }
                }
            } while (mainChoice == "yes");
        }
        //Main menu ends
        /// <summary>
        /// User registration for registering the user details <see cref="Operations"/>
        /// </summary>
        /// 
        //User Registration
        public static void UserRegistration()
        {
            //Getting user details
            Console.Write("Enter your User name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter your gender(Male/Female): ");
            Gender gender;
            bool temp = Enum.TryParse(Console.ReadLine(), true, out gender);
            while (!temp)
            {
                Console.Write("Entered value is wrong\nPlease try again in (Male,Female) format: ");
                temp = Enum.TryParse(Console.ReadLine(), true, out gender);
            }
            Console.Write("Enter your Deaprtment(CSE/ECE/EEE): ");
            Department department;
            bool temp1 = Enum.TryParse(Console.ReadLine(), true, out department);
            while (!temp1)
            {
                Console.Write("Entered value is wrong\nPlease try again in (CSE/ECE/EEE) format: ");
                temp1 = Enum.TryParse(Console.ReadLine(), true, out department);
            }
            Console.Write("Enter your mobile Number in (9998565865) format: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter your EmailID in (satti@gmail.com) format: ");
            string emailID = Console.ReadLine();
            Console.Write("Enter your Wallet Balance (enter amount greater than 0): ");
            double walletBalance = double.Parse(Console.ReadLine());
            

            //creating an object and adding into the list
            UserDetails user = new UserDetails(userName, gender, department, mobileNumber, emailID, walletBalance);
            userList.Add(user);

            //Display user ID
            Console.WriteLine("User Registered successfully. Your user ID :" + user.UserId);


        }
        //User registration ends

        /// <summary>
        /// User login to get login of specified user and perform operation <see cref="Operations"/>
        /// </summary>
        /// 
        //User Login
        public static void UserLogin()
        {
            //getting the user id from the user
            Console.Write("Enter your User ID: ");
            string userID = Console.ReadLine();

            //validate the user id in the list
            bool isValid = false;
            int subMenuOption;
            foreach (UserDetails user in userList)
            {
                if (userID.Equals(user.UserId))
                {
                    Console.WriteLine("Login Successfull");
                    isValid = true;
                    currentLoggedInUser = user;
                    string subMenuExit="yes";
                    do
                    {
                        Console.WriteLine("***************Sub Menu***************");
                        Console.WriteLine("1. Borrow Book\n2. Show Borrowed History\n3. Return Books\n4. Wallet Recharge\n5. Exit");
                        //get the option from the user
                        subMenuOption = int.Parse(Console.ReadLine());
                        
                        switch (subMenuOption)
                        {
                            case 1:
                                {
                                    Console.WriteLine("***************Borrow Book***************");
                                    BorrowBook();
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("***************Show Borrowed History***************");
                                    ShowBorrowedHistory();
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("***************Return Books***************");
                                    ReturnBook();
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("***************Wallet Recharge***************");
                                    WalletRecharge();

                                    break;
                                }
                            case 5:
                                {
                                    Console.WriteLine("Going to Main Menu");
                                    subMenuExit="no";
                                    break;
                                }
                        }
                    } while (subMenuExit=="yes");
                }
            }
            if(!isValid)
            {
               Console.WriteLine("Invalid user ID");
            }
            //show sub menu if validates

        }
        //User Login ends

        /// <summary>
        /// To borrow book from the library <see cref="Operations"/>
        /// </summary>
 
        //Borrow Book
        public static void BorrowBook()
        {
            //Print the books available
            PrintBookAvailable();
            //Ask the user for the book he want by entering book ID
            Console.Write("Enter the book ID of the book you need: ");
            string bookID = Console.ReadLine().ToUpper();

            //Check Book ID  is available or not
            bool isAvailable = false;
            foreach (BookDetails book in bookList)
            {
                if (book.BookID.Equals(bookID))
                {
                    isAvailable = true;
                    //Enter the count of the book
                    Console.Write("Enter number of books you need: ");
                    int booksNeeded = int.Parse(Console.ReadLine());
                    //Check the book count availability
                    if(booksNeeded>3)
                    {
                        Console.WriteLine("Only 3 books can be borrowed by an person.");
                        break;
                    }
                    else if (book.BookCount >= booksNeeded)
                    {

                        //check whether the user already borrowed any book max 3
                        int bookCount = 0;
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.UserID.Equals(currentLoggedInUser.UserId) && borrow.Status.Equals(Status.Borrowed))
                            {
                                bookCount += borrow.BorrowBookCount;
                            }
                        }
                        //if user borrwed 3 books already display message
                        if (bookCount == 3)
                        {
                            Console.WriteLine("You have borrowed 3 books already");
                            break;
                        }
                        //if user borrowed count and request book count exceeds display message
                        else if (bookCount + booksNeeded > 3)
                        {
                            Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {bookCount} and requested count is {booksNeeded}, which exceeds 3 ");
                            break;
                        }
                        //else allocate book to user set status  borrowed and borrow date today 
                        BorrowDetails newBorrow = new BorrowDetails(bookID, currentLoggedInUser.UserId, DateTime.Now, booksNeeded, Status.Borrowed, 0);
                        book.BookCount-=booksNeeded;
                        //create borrow details and store it
                        borrowList.Add(newBorrow);
                        Console.WriteLine("Borrwed Book successfully.");
                    }
                    //if no books available display message
                    else
                    {
                        Console.WriteLine("Books are not available for the selected count");
                        //Print next available date of book by getting books borroweddate from borrowed history and adding 15 days
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.BookID.Equals(bookID))
                            {
                                DateTime borrowedDate = borrow.BorrowedDate;
                                DateTime nextAvilableDate = borrowedDate.AddDays(15);
                                //Display the book available date
                                Console.WriteLine("The book will be available on: " + nextAvilableDate.ToString("dd/MM/yyyy"));
                            }
                        }

                    }



                }
            }
            if (!isAvailable)
            {
                Console.WriteLine("Invalid Book ID, Please enter valid ID");
            }



            //If not display message
        }
        //Borrow book ends

        /// <summary>
        /// 
        /// To print the books available
        /// 
        /// </summary>

        public static void PrintBookAvailable()
        {
            int count = 0;
            foreach (BookDetails book in bookList)
            {
                if (book.BookCount > 0)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("|BookID|BookName|AuthorName|BookCount|");

                foreach (BookDetails book in bookList)
                {
                    if (book.BookCount > 0)
                    {
                        Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");
                    }
                }
            }
        }
        /// <summary>
        /// To print the borrowed books details of the user <see cref="Operations"/>
        /// </summary>
        /// //Show borrowed history
        public static void ShowBorrowedHistory()
        {
            //show the current users borrowed books history
            int count = 0;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (borrow.UserID.Equals(currentLoggedInUser.UserId))
                {
                    count++;
                }
            }
            if (count != 0)
            {
                Console.WriteLine("|BorrowID|BookID|UserID|BorrowedDate|BorrowBookCount|Status|PaidFineAmount|");
                foreach (BorrowDetails borrow in borrowList)
                {
                    if (borrow.UserID.Equals(currentLoggedInUser.UserId))
                    {
                        Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate.ToString("dd/MM/yyyy")}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|");
                    }
                }
            }
            else
            {
                Console.WriteLine("You did not borrowed any book to display.");
            }
        }
        //show borrowed history ends
        
        /// <summary>
        /// To return the book the user borrowed <see cref="Operations"/>
        /// </summary>
        /// //return book
        public static void ReturnBook()
        {
            //Check if the user borrowed a book or not
            int count = 0;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentLoggedInUser.UserId.Equals(borrow.UserID) && borrow.Status.Equals(Status.Borrowed))
                {
                    count++;
                }
            }
            if (count != 0)
            {
                //Print the borrowed book details with return date and if fine is there
                Console.WriteLine("|BorrowID|BookID|UserID|BorrowedDate|BorrowBookCount|Status|PaidFineAmount|Return Date|Fine amount|");
                foreach (BorrowDetails borrow in borrowList)
                {
                    DateTime returnDate=borrow.BorrowedDate.AddDays(15);
                    if (currentLoggedInUser.UserId.Equals(borrow.UserID) && borrow.Status.Equals(Status.Borrowed))
                    {
                        if (DateTime.Now>returnDate)
                        {
                            TimeSpan span=DateTime.Now-returnDate;
                            int numberOfDaysElapsed=span.Days;
                            int fineAmount=numberOfDaysElapsed*1;
                            Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate.ToString("dd/MM/yyyy")}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|{returnDate.ToString("dd/MM/yyyy")}|{fineAmount}");
                        }
                        else
                        {
                            Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate.ToString("dd/MM/yyyy")}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|{returnDate.ToString("dd/MM/yyyy")}|0");
                        }
                        

                    }
                }
                //Take input from the user which book he want to return
                Console.Write("Enter the bookID you want to return: ");
                string bookID=Console.ReadLine().ToUpper();
                //check if the book is present in the list
                foreach (BorrowDetails borrow in borrowList)
                {
                    int fineAmount;
                    if(bookID.Equals(borrow.BookID) && borrow.Status.Equals(Status.Borrowed) && currentLoggedInUser.UserId.Equals(borrow.UserID))
                    {
                        DateTime returnDate=borrow.BorrowedDate.AddDays(15);
                        TimeSpan span=DateTime.Now-returnDate;
                        int numberOfDaysElapsed=span.Days;
                        if(numberOfDaysElapsed<0)
                        {
                             fineAmount=0;
                        }
                        else
                        {
                             fineAmount=numberOfDaysElapsed*1;
                        }
                        
                        if(currentLoggedInUser.WalletBalance>fineAmount)
                        {
                            //cut the fine amount from the wallet of the user
                            
                            currentLoggedInUser.DeductAmount(fineAmount);
                            //make the status to returned
                            borrow.Status=Status.Returned;
                            borrow.PaidFineAmount=fineAmount;
                            Console.WriteLine("Book returned successfully.");
                            //return the b ook into booklist
                            foreach(BookDetails book in bookList)
                            {
                                if(borrow.BookID.Equals(book.BookID))
                                {
                                    book.BookCount+=borrow.BorrowBookCount;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance. Please rechange and proceed");
                            break;
                        }
                    }
                    
                    
                }
            }
            else
            {
                Console.WriteLine("You did not borrowed any books to return.");
            }
        }
        //return books ends

        //Wallet Recharge
        public static void WalletRecharge()
        {
            Console.Write("Enter the amount you want to recharge: ");
            double amount = double.Parse(Console.ReadLine());
            if (amount > 0)
            {
                Console.WriteLine("Amount added successfully\nYour wallet balance is: " + currentLoggedInUser.WalletRecharge(amount));
            }
            else
            {
                Console.WriteLine("Enter the value greater than 0 and try again to recharge.");
            }
        }
        //Wallet Recharge ends
        //Default values
        public static void DefaultValues()
        {
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, "9938388333", "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, "9944444455", "priya@gmail.com", 150);
            userList.AddRange(new List<UserDetails>() { user1, user2 });

            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            bookList.AddRange(new List<BookDetails>() { book1, book2, book3, book4, book5 });

            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);
            borrowList.AddRange(new List<BorrowDetails>() { borrow1, borrow2, borrow3, borrow4, borrow5 });

        }
        //Default values ends

        //Main menu

    }
}