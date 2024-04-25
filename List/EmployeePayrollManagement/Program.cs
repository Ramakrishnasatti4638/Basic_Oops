using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace EmployeePayrollManagement;
class Program 
{

    static List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
    static bool isSet=true;
    public static void Main(string[] args)
    {
        string check="";
        do
        {
            System.Console.WriteLine("-----------------------Menu--------------------------");
            System.Console.WriteLine("1.Registration");
            System.Console.WriteLine("2.Login");
            System.Console.WriteLine("3.Exit");
            System.Console.WriteLine("Enter Your Option: ");
            int option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Register();
                    System.Console.WriteLine("Do you want to continue");
                    check=Console.ReadLine();
                    break;
                }
                case  2:
                {
                    Login();
                    if(isSet)
                    {
                        System.Console.WriteLine("Do you want to continue");
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
                    System.Console.WriteLine("Invalid input");
                    System.Console.WriteLine("Do you want to continue");
                    check=Console.ReadLine();
                    break;
                }
            }

        }while(check=="yes");
    }

    public static void Register()
    {
        System.Console.WriteLine("Enter your name: ");
        string employeeName=Console.ReadLine();
        System.Console.WriteLine("Enter your role: ");
        string employeeRole=Console.ReadLine();
        System.Console.WriteLine("Enter your work location (Hyderabad, Chennai): ");
        WorkLocation employeeWorkLocation;
        bool temp=Enum.TryParse<WorkLocation>(Console.ReadLine(),true,out employeeWorkLocation);
        while(!temp)
        {
            System.Console.WriteLine("Invalid location \nPlease try again: ");
            temp=Enum.TryParse<WorkLocation>(Console.ReadLine(),true,out employeeWorkLocation);
        }
        System.Console.WriteLine("Enter your team name: ");
        string employeeTeamName=Console.ReadLine();
        System.Console.WriteLine("Enter your date of joining (dd/MM/yyyy): ");
        DateTime employeeDoj;
        bool temp1=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out employeeDoj);
        while(!temp1)
        {
            System.Console.WriteLine("Date entered in invalid format \nPlease try  again ");
            temp1=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out employeeDoj);
        }
        System.Console.WriteLine("Enter number of working days in a month: ");
        int employeeNoOfWorkingDays=int.Parse(Console.ReadLine());
        System.Console.WriteLine("Enter number of leaves taken: ");
        int employeeNoOfLeaves=int.Parse(Console.ReadLine());
        Gender gender;
        System.Console.WriteLine("Enter your Gender(Male, Female): ");
        bool temp2=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        while(!temp2)
        {
            System.Console.WriteLine("Entered gender is not correct\nPlease renter again: ");
            temp2=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        }

        EmployeeDetails employee=new EmployeeDetails(employeeName,employeeRole,employeeWorkLocation,employeeTeamName,
        employeeDoj,employeeNoOfWorkingDays,employeeNoOfLeaves,gender);
        employeeList.Add(employee);


        
    }

    public static void Login()
    {
        System.Console.WriteLine("Enter your Employee ID: ");
        string employeeID=Console.ReadLine();
        bool flag=false;
        
        foreach(EmployeeDetails employee in employeeList)
        {
            if(employee.EmployeeID==employeeID)
            {
                flag=true;
                System.Console.WriteLine("1. Calculate Salary");
                System.Console.WriteLine("2. Display Details");
                System.Console.WriteLine("3. Exit");
                System.Console.WriteLine("Enter your option: ");
                int newOption=int.Parse(Console.ReadLine());
                switch (newOption)
                {
                    case 1:
                    {
                        employee.CalculateSalary();
                        isSet=true;
                        break;
                    }
                    case 2:
                    {
                        System.Console.WriteLine("Employee ID: "+employee.EmployeeID);
                        System.Console.WriteLine("Employee Name: "+employee.EmployeeName);
                        System.Console.WriteLine("Employee Role: "+employee.EmployeeRole);
                        System.Console.WriteLine("Employee Work Location: "+employee.EmployeeWorkLocation);
                        System.Console.WriteLine("Employee Team Name: "+employee.EmployeeTeamName);
                        System.Console.WriteLine("Employee Date of Joining: "+employee.DOJ.ToString("dd/MM/yyyy"));
                        System.Console.WriteLine("Employee Working Days in a Month: "+employee.NoOfWorkingDays);
                        System.Console.WriteLine("Employee Leaves taken: "+employee.NoOfLeaves);
                        System.Console.WriteLine("Employee Gender: "+employee.Gender);
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
            if(!flag)
            {
                System.Console.WriteLine("Invalid user id.");
            }
        }
    }
}