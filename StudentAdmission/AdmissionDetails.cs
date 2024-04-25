using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
   
    public enum AdmissionStatus { Select, Admitted, Cancelled }
     /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="AdmissionDetails"/>
    /// </summary>
    public class AdmissionDetails
    {

        /*
        a.	AdmissionID – (Auto Increment ID - AID1001)
        b.	StudentID
        c.	DepartmentID
        d.	AdmissionDate
        e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)

        */
        //Field
        //Static Field
        /// <summary>
        /// 
        /// Static field s_admissionID used to autoincrement StudentID of the instance of <see cref="AdmissionDetails" />
        /// 
        /// </summary>
        private static int s_admissionID = 1000;

        //Properties

         /// <summary>
        /// AdmissionID Property used to hold a Admission ID of the instance of <see cref="AdmissionDetails" />
        /// </summary> <summary>
        /// 
        /// </summary>
        
        public string AdmissionID { get; }

         /// <summary>
        /// 
        /// StudentID Property used to hold a Student's ID of the instance of <see cref="AdmissionDetails" />
        /// 
        /// </summary>
        /// <value></value>
        public string StudentID { get; set; }

        /// <summary>
        /// 
        /// DepartmentID Property used to hold a Department's ID of the instance of <see cref="AdmissionDetails" />
        /// 
        /// </summary>
        /// <value></value>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 
        /// AdmissionDate Property used to hold Admission Date of the instance of <see cref="AdmissionDetails" />
        /// 
        /// </summary>
        /// <value></value>
        public DateTime AdmissionDate { get; set; }

        /// <summary>
        /// AdmissionStatus Property used to hold Admission Status of the instance of <see cref="AdmissionDetails" />
        /// </summary>
        /// <value></value>
        public AdmissionStatus AdmissionStatus { get; set; }

        //Constructor
         /// <summary>
        /// Parametrized AdmissionDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="admissionID"></param>
        /// <param name="studentID"></param>
        /// <param name="departmentID"></param>
        /// <param name="admissionDate"></param>
        /// <param name="admissionStatus"></param>
        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            //Auto increment
            s_admissionID++;

            AdmissionID = "AID" + s_admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

        public AdmissionDetails(string admission)
        {
            string[] values=admission.Split(",");

            AdmissionID = values[0];
            s_admissionID=int.Parse(values[0].Remove(0,3));
            StudentID = values[1];
            DepartmentID = values[2];
            AdmissionDate = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            AdmissionStatus = Enum.Parse<AdmissionStatus>(values[4]);
        }
    }
}