using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
namespace PayrollManagementSystem;
class Program 
{
    static List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
    static List<AttendanceDetails> attendanceList=new List<AttendanceDetails>();
    static DateTime checkOutTime;
    static DateTime checkInTime;
    static bool checkIn=false;
    static bool checkOut=false;
    static bool isSet=true;
    //static int employeeHoursWorked;
    public static void Main(string[] args)
    {
        DefaultValues();
        string mainMenu="";
        do
        {
            System.Console.WriteLine("------------------Welcome to Payroll Management System--------------------");
            System.Console.WriteLine("1. Employee Registration");
            System.Console.WriteLine("2. Employee Login");
            System.Console.WriteLine("3. Exit");
            System.Console.WriteLine("Enter your option from above: ");
            int option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Registration();
                    System.Console.WriteLine("Do you want to continue: ");
                    mainMenu=Console.ReadLine();
                    break;
                }
                case 2:
                {
                    Login();
                    if(isSet)
                    {
                        System.Console.WriteLine("Do you want to continue: ");
                        mainMenu=Console.ReadLine();
                    }
                    mainMenu="yes";
                    break;
                }
                case 3:
                {
                    Environment.Exit(0);
                    break;
                }
            }

        } while (mainMenu=="yes");
    }

    public static void DefaultValues()
    {
        DateTime employeeDOB;
        DateTime.TryParse("11/11/1999",null,out employeeDOB);
        Gender gender;
        Enum.TryParse<Gender>("Male",true,out gender);
        Branch employeeBranch;
        Enum.TryParse<Branch>("Eymard",true,out employeeBranch);
        Team employeeTeam;
        Enum.TryParse<Team>("Developer",true,out employeeTeam);
        EmployeeDetails employee=new EmployeeDetails("","Ravi",employeeDOB,"9958858888",gender,employeeBranch,employeeTeam);
        employeeList.Add(employee);

        DateTime date;
        DateTime.TryParseExact("15/05/2022","dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out date);
        DateTime checkInTime;
        DateTime.TryParse("09:00 AM",null,out checkInTime);
        DateTime checkOutTime;
        DateTime.TryParse("06:10 PM",null,out checkOutTime);
        AttendanceDetails attendance=new AttendanceDetails("",employee.EmplyeeID,date,checkInTime,checkOutTime,8);
        attendanceList.Add(attendance);
    }

    public static void Registration()
    {
        System.Console.WriteLine("                Registration Form                  ");
        System.Console.WriteLine("Enter your Name: ");
        string employeeName=Console.ReadLine();
        System.Console.WriteLine("Enter your Date of Birth: ");
        DateTime employeeDOB;
        bool temp=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out employeeDOB);
        while(!temp)
        {
            System.Console.WriteLine("Entered date in wrong format Please try again in (dd/MM/yyyy) format ");
            temp=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out employeeDOB);
        }
        System.Console.WriteLine("Enter your Mobile Number: ");
        string employeeNumber=Console.ReadLine();
        System.Console.WriteLine("Enter your Gender(Male,Female): ");
        Gender employeeGender;
        bool temp1=Enum.TryParse<Gender>(Console.ReadLine(),true,out employeeGender);
        while(!temp1)
        {
            System.Console.WriteLine("Entered value is wrong please try again: ");
            temp1=Enum.TryParse<Gender>(Console.ReadLine(),true,out employeeGender);
        }
        System.Console.WriteLine("Enter your Branch Name (Eymard,Karuna,Madhura): ");
        Branch employeeBranch;
        bool temp2=Enum.TryParse<Branch>(Console.ReadLine(),true,out employeeBranch);
        while(!temp2)
        {
            System.Console.WriteLine("Entered value is wrong please try again: ");
            temp2=Enum.TryParse<Branch>(Console.ReadLine(),true,out employeeBranch);
        }
        System.Console.WriteLine("Enter your Team Name(Network, Hardware, Developer, Facility): ");
        Team employeeTeam;
        bool temp3=Enum.TryParse<Team>(Console.ReadLine(),true,out employeeTeam);
        while(!temp3)
        {
            System.Console.WriteLine("Entered value is wrong please try again: ");
            temp3=Enum.TryParse<Team>(Console.ReadLine(),true,out employeeTeam);
        }
        EmployeeDetails employee=new EmployeeDetails("",employeeName,employeeDOB,employeeNumber,employeeGender,employeeBranch,employeeTeam);
        employeeList.Add(employee);
        System.Console.WriteLine($"Employee added successfully your id is: {employee.EmplyeeID}");
        
    }

    public static void Login()
    {
        System.Console.WriteLine("Enter your EmployeeID: ");
        string employeeID=Console.ReadLine();
        EmployeeDetails employee=employeeList.Find(x=>x.EmplyeeID==employeeID);
        if(employee==null)
        {
            System.Console.WriteLine("Invalid userID");
            return;
        }
        do
        {
            System.Console.WriteLine("i. Add Attendance");
            System.Console.WriteLine("ii. Display Details");
            System.Console.WriteLine("iii. Calculate Salary");
            System.Console.WriteLine("iv. Exit");
            System.Console.WriteLine("Enter your option from above: ");
            string newOption=Console.ReadLine();
            switch(newOption)
            {
                case "i":
                {
                    AddAttendance(employee);
                    isSet=true;
                    break;
                }
                case "ii":
                {
                    DisplayDetails(employee);
                    isSet=true;
                    break;
                }
                case "iii":
                {
                    CalculateSalary(employee);
                    isSet=true;
                    break;
                }
                case "iv":
                {
                    isSet=false;
                    return;
                }
            }
        }while(true);
    }

    public static void AddAttendance(EmployeeDetails employee)
    {
        
        System.Console.WriteLine("Do you want to Check In (yes/no): ");
        string checkInOption=Console.ReadLine();
        if(checkInOption=="yes" && checkIn==false)
        {
            System.Console.WriteLine("Enter the date and time of check in (dd/MM/yyyy hh:mm:ss ff)");
            DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm:ss tt",null,System.Globalization.DateTimeStyles.None,out checkInTime);
            checkIn=true;
        }
        else if(checkInOption=="no")
        {
            return;
        } 
        else
        {
            System.Console.WriteLine("You had already checked in");
            
        }
        System.Console.WriteLine("Do you want to Check Out (yes/no): ");
        string checkOutOption=Console.ReadLine();
        if(checkOutOption=="yes" && checkOut==false)
        {
            System.Console.WriteLine("Enter the date and time of check out (dd/MM/yyyy hh:mm:ss ff)");
            DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm:ss tt",null,System.Globalization.DateTimeStyles.None,out checkOutTime);
            checkIn=false;
        }
        else if(checkOutOption=="no")
        {
            return;
        } 
        else
        {
            System.Console.WriteLine("Entered wrong output\nPlease try again.");
            return;
        }
        TimeSpan span=checkOutTime-checkInTime;
        if(span.Hours<8)
        {
            System.Console.WriteLine("You had worked less than 8 hours.It will be marked as absent.");
            return;
        }
        AttendanceDetails attendance=new AttendanceDetails("",employee.EmplyeeID,checkInTime,checkInTime,checkOutTime,8);  
        attendanceList.Add(attendance);
        System.Console.WriteLine("Check-in and Checkout Successful and today you have worked 8 Hours"); 
    }

    public static void DisplayDetails(EmployeeDetails employee)
    {
        System.Console.WriteLine("EmployeeID    Full Name        DOB          MobileNumber      Gender      Branch       Team");
        System.Console.WriteLine($"{employee.EmplyeeID}        {employee.EmployeeName}         {employee.EmployeeDOB.ToString("dd/MM/yyyy")}       {employee.EmployeeNumber}        {employee.EmployeeGender}        {employee.EmployeeBranch}      {employee.EmployeeTeam}");
    }

    public static void CalculateSalary(EmployeeDetails employee)
    {
       
        System.Console.WriteLine("AttendanceID    EmployeeID          Date         CheckInTime        CheckOutTime        HoursWorked");
        foreach(AttendanceDetails user in attendanceList)
        {
            if(user.EmployeeID==employee.EmplyeeID && user.Date.ToString("MM")==DateTime.Now.ToString("MM"))
            {
                System.Console.WriteLine($"{user.AttendanceID}          {user.EmployeeID}         {user.Date.ToString("dd/MM/yyyy")}       {user.EmployeeCheckInTime.ToString("HH:mm tt")}             {user.EmployeeCheckOutTime.ToString("HH:mm tt")}           {user.EmployeeHoursWorked}");
            }
        }
        string month=DateTime.Now.ToString("MM");
        int count=0;
        foreach(AttendanceDetails user in attendanceList)
        {
            if(user.EmployeeID==employee.EmplyeeID && user.Date.ToString("MM")==month)
            {
                count++;
            }
        }
        System.Console.WriteLine("Your salary is "+count*500);
    }

}