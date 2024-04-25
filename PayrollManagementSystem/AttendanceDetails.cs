using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    public class AttendanceDetails
    {
        private static int s_attendanceID=1000;
        public string AttendanceID { get; }
        public string EmployeeID { get; }
        public DateTime Date { get; set; }
        public DateTime EmployeeCheckInTime { get; set; }
        public DateTime EmployeeCheckOutTime { get; set; }
        public int EmployeeHoursWorked { get; set; }

        public AttendanceDetails(string attendanceID,string employeeID,DateTime date,DateTime employeeCheckInTime,DateTime employeeCheckOutTime,int employeeHoursWorked)
        {
            s_attendanceID++;
            AttendanceID="AID"+s_attendanceID;
            EmployeeID=employeeID;
            Date=date;
            EmployeeCheckInTime=employeeCheckInTime;
            EmployeeCheckOutTime=employeeCheckOutTime;
            EmployeeHoursWorked=employeeHoursWorked;
        }
    }
}