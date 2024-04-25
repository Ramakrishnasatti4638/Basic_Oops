using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    public enum Gender {Select,Male,Female}
    public enum Branch {Select,Eymard,Karuna,Madhura}
    public enum Team {Select,Network,Hardware,Developer,Facility}
    public class EmployeeDetails
    {
        private static int s_employeeID=3000;
        public string EmplyeeID { get; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public string EmployeeNumber { get; set; }
        public Gender EmployeeGender { get; set; }
        public Branch EmployeeBranch { get; set; }
        public Team EmployeeTeam { get; set; }

        public EmployeeDetails(string employeeID,string employeeName,DateTime employeeDOB,string employeeNumber,Gender gender,Branch employeeBranch,Team employeeTeam)
        {
            s_employeeID++;
            EmplyeeID="SF"+s_employeeID;
            EmployeeName=employeeName;
            EmployeeDOB=employeeDOB;
            EmployeeNumber=employeeNumber;
            EmployeeGender=gender;
            EmployeeBranch=employeeBranch;
            EmployeeTeam=employeeTeam;
            
        }

    }
}