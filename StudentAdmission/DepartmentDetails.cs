using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    /// <summary>
    /// 
    /// Class DepartmentDetails used to create instance for student <see cref="DepartmentDetails"/>
    /// 
    /// </summary>
    public class DepartmentDetails
    {
        /*
        a.	DepartmentID – (AutoIncrement - DID101)
        b.	DepartmentName
        c.	NumberOfSeats

        */

        //Field
        //Static Field
        /// <summary>
        ///  Static field s_departmentID used to autoincrement DepartmentID of the instance of <see cref="DepartmentDetails" />
        /// </summary>
        private static int s_departmentID=100;

        //Properties

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

        //Constructor

        /// <summary>
        /// Parametrized DepartmentDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="departmentName"></param>
        /// <param name="numberOfSeats"></param>
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            //Auto increment
            s_departmentID++;

            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }

        public DepartmentDetails(string depatment)
        {
            string[] values=depatment.Split(",");

            DepartmentID=values[0];
            s_departmentID=int.Parse(values[0].Remove(0,3));
            DepartmentName=values[1];
            NumberOfSeats=int.Parse(values[2]);
        }
    }
}