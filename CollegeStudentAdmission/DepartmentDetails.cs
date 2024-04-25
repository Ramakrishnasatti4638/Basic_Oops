using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// 
    /// Class DepartmentDetails used to create instance for student <see cref="DepartmentDetails"/>
    /// 
    /// </summary>
    public class DepartmentDetails
    {
        /// <summary>
        ///  Static field s_departmentID used to autoincrement DepartmentID of the instance of <see cref="DepartmentDetails" />
        /// </summary>
        private static int s_departmentID = 100;

        /// <summary>
        /// DepartmentID Property used to hold a Department ID of the instance of <see cref="DepartmentnDetails" />
        /// </summary>
        /// <value></value>
        public string DepartmentID { get; }

        /// <summary>
        /// DepartmentName Property used to hold a Department Name of the instance of <see cref="DepartmentnDetails" />
        /// </summary>
        /// <value></value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// NumberOfSeats Property used to hold a Number of Seats of the instance of <see cref="DepartmentnDetails" />
        /// </summary>
        /// <value></value>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Parametrized DepartmentDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="departmentName"></param>
        /// <param name="numberOfSeats"></param>
        public DepartmentDetails(string departmentID,string departmentName,int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }
    }
}