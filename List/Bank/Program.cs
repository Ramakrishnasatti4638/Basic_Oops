using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
namespace Bank;
class Program 
{
    static List<CustomerDetails> customerList=new List<CustomerDetails>();
    static bool isSet=true;
    public static void Main(string[] args)
    {

        
        string check="";
        do
        {
            System.Console.WriteLine("Menu");
            System.Console.WriteLine("1.Registration.");
            System.Console.WriteLine("2.Login.");
            System.Console.WriteLine("3.Exit.");
            System.Console.Write("Enter your option: ");
            int option=int.Parse(Console.ReadLine());

           
            
            switch(option)
            {
                case 1:
                {
                    Register();
                    System.Console.WriteLine("do you want to continue");
                    check=Console.ReadLine();
                    break;
                }

                case 2:
                {
                    Login();
                    if(isSet)
                    {
                        System.Console.WriteLine("do you want to continue");
                        check=Console.ReadLine();
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
                    System.Console.WriteLine("Invalid choice please enter again.");
                    System.Console.WriteLine("do you want to continue");
                    check=Console.ReadLine();
                    break;
                }
            }
            
            
        }while(check=="yes");
    }
    public static void Register()
    {
                System.Console.Write("Enter your name: ");
                string name=Console.ReadLine();
                System.Console.Write("Enter balance: ");
                long balance=long.Parse(Console.ReadLine());
                System.Console.Write("Enter your gender(Male,Female): ");
                Gender gender;
                bool temp=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                while(!temp)
                {
                    System.Console.WriteLine("Invalid gender input \nPlease try again ");
                    temp=Enum.TryParse(Console.ReadLine(),true,out gender);
                }
                System.Console.Write("Enter Phone Number: ");
                long number=long.Parse(Console.ReadLine());
                System.Console.Write("Enter your Mail Id: ");
                string mailId=Console.ReadLine();
                System.Console.Write("Enter your date of birth: ");
                DateTime dob;
                bool temp1=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
                while(!temp1)
                {
                    System.Console.WriteLine("Invalid date format.\nPlease enter again ");
                    temp1=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
                }
                CustomerDetails customer=new CustomerDetails(name,balance,gender,number,mailId,dob);
                customerList.Add(customer);
                System.Console.WriteLine("Registration Successfull. Your customer ID is "+ customer.CustomerID);
                
    }

    public static void Login()
    {
                bool flag=true;
                System.Console.Write("Enter You customer id: ");
                string customerId=Console.ReadLine().ToUpper();
                foreach(CustomerDetails customer in customerList)
                {
                    if(customer.CustomerID==customerId)
                    {
                        flag=false;
                        System.Console.WriteLine("1.Deposit");
                        System.Console.WriteLine("2.Withdraw");
                        System.Console.WriteLine("3.Balance check");
                        System.Console.WriteLine("4.Exit");
                        System.Console.Write("Enter your option: ");
                        int newOption=int.Parse(Console.ReadLine());
                        switch(newOption)
                        {
                            case 1:
                            {
                                System.Console.Write("Enter the amount to deposit: ");
                                long amount=long.Parse(Console.ReadLine());
                                customer.Deposit(amount);
                                isSet=true;
                                break;
                            }
                            case 2:
                            {
                                System.Console.Write("Enter the amount to Withdraw: ");
                                long amount=long.Parse(Console.ReadLine());
                                customer.WithDraw(amount);
                                isSet=true;
                                break;
                            }
                            case 3:
                            {
                                System.Console.WriteLine("Your balance is "+customer.Balance);
                                isSet=true;
                                break;
                            }
                            case 4:
                            {
                                isSet=false;
                                return ;
                            }
                        }
                        
                    }
                }
                if(flag)
                {
                    System.Console.WriteLine("Invalid user ID.");
                }
                
    }
    
    

    
}