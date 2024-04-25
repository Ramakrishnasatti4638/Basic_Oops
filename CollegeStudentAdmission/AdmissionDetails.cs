using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="AdmissionDetails"/>
    /// </summary>
    public class AdmissionDetails
    {
        /// <summary>
        /// 
        /// Static field s_admissionID used to autoincrement StudentID of the instance of <see cref="AdmissionDetails" />
        /// 
        /// </summary>
        private static int s_admissionID=1000;
        
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
        public string StudentID { get; }

        /// <summary>
        /// 
        /// DepartmentID Property used to hold a Department's ID of the instance of <see cref="AdmissionDetails" />
        /// 
        /// </summary>
        /// <value></value>
        public string DepartmentID { get; }

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
        public string AdmissionStatus { get; set; }

        /// <summary>
        /// Parametrized AdmissionDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="admissionID"></param>
        /// <param name="studentID"></param>
        /// <param name="departmentID"></param>
        /// <param name="admissionDate"></param>
        /// <param name="admissionStatus"></param>
        public AdmissionDetails(string admissionID,string studentID,string departmentID,DateTime admissionDate,string admissionStatus)
        {
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }
    }
}