using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace EbBillCalculation;
class Program 
{

    static List<UserDetails> userList=new List<UserDetails>();
    static bool isSet=true;
    public static void Main(string[] args)
    {

        string check="";
        do
        {

            System.Console.WriteLine("---------------------------Menu------------------------------");
            System.Console.WriteLine("1.Registration");
            System.Console.WriteLine("2.Login");
            System.Console.WriteLine("3.Exit");
            System.Console.WriteLine("Enter your option : ");
            int option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Registration();
                    System.Console.WriteLine("Do you want to continue: ");
                    check=Console.ReadLine().ToLower();
                    
                    break;
                }
                case 2:
                {
                    Login();
                    if(isSet)
                    {
                        System.Console.WriteLine("Do you want to continue: ");
                        check=Console.ReadLine().ToLower();
                    }
                    
                    break;
                }
                case 3:
                {
                    Environment.Exit(0);

                    break;
                }
                default:
                {
                    System.Console.WriteLine("Entered option is not correct \nPlease try again");
                    break;
                }
            }

        }while(check=="yes");
    }


    public static void Registration()
    {
        System.Console.WriteLine("Enter your Username: ");
        string userName=Console.ReadLine();
        System.Console.WriteLine("Enter your Number: ");
        string number=Console.ReadLine();
        System.Console.WriteLine("Enter MailID: ");
        string mailID=Console.ReadLine();
        
        UserDetails user=new UserDetails(userName,number,mailID);
        System.Console.WriteLine("Your MeterID is "+user.MeterID);
        userList.Add(user);
    }

    public static void Login()
    {
        System.Console.WriteLine("Enter your MeterID: ");
        string meterId=Console.ReadLine().ToUpper();
        bool isIn=false;
        foreach(UserDetails user in userList)
        {
            if(user.MeterID==meterId)
            {
                isIn=true;
                System.Console.WriteLine("1.Calculate Amount");
                System.Console.WriteLine("2.Display user details");
                System.Console.WriteLine("3.Exit");
                System.Console.WriteLine("Enter your option: ");
                int newOption=int.Parse(Console.ReadLine());
                switch(newOption)
                {
                    case 1:
                    {
                        user.CalculateAmount();
                        isSet=true;
                        break;
                    }
                    case 2:
                    {
                        System.Console.WriteLine("Your MeterID is "+user.MeterID);
                        System.Console.WriteLine("Your UserName is "+user.Username);
                        System.Console.WriteLine("Your Phone number is "+user.Number);
                        System.Console.WriteLine("Your EmailID is "+user.MailID);
                        isSet=true;
                        break;
                    }
                    case 3:
                    {
                        isSet=false;
                        return ;
                    
                    }
                }
            }
        }
        if(!isIn)
        {
            System.Console.WriteLine("Invalid user id.");
        }
    }
}