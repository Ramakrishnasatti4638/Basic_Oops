using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    public enum WorkLocation{Select, Chennai, Hyderabad}
    public enum Gender{Select, Male, Female}
    public class EmployeeDetails
    {

        private static int s_employeeID=1000;
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string EmployeeRole { get; set; }

        public WorkLocation EmployeeWorkLocation { get; set; }
        public string EmployeeTeamName { get; set; }
        public DateTime DOJ { get; set; }
        public int NoOfWorkingDays { get; set; }
        public int NoOfLeaves { get; set; }
        public Gender Gender { get; set; }




        public EmployeeDetails(string employeeName,string employeeRole,WorkLocation employeeWorkLocation,string employeeTeamName,
        DateTime doj,int employeeNoOfWorkingDays,int employeeNoOfLeaves,Gender gender)
        {
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;
            EmployeeName=employeeName;
            EmployeeRole=employeeRole;
            EmployeeWorkLocation=employeeWorkLocation;
            EmployeeTeamName=employeeTeamName;
            DOJ=doj;
            NoOfWorkingDays=employeeNoOfWorkingDays;
            NoOfLeaves=employeeNoOfLeaves;
            Gender=gender;
        }
        public void CalculateSalary()
        {
            if(NoOfLeaves>=NoOfWorkingDays)
            {
                System.Console.WriteLine("Your salary is 0");
            }
            else
            {
                int salary=(NoOfWorkingDays-NoOfLeaves)*500;
                System.Console.WriteLine("Your salary is : "+salary);
            }
        }
    }

    
}