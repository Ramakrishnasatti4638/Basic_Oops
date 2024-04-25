using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// DataType Gender used to select a instance of <see cref="StudentDetails"/> Gender Information 
    /// </summary>
    public enum Gender {Select, Male, Female, Transgender}

    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails"/>
    /// Refer documentation on <see href="www.syncfusion.com" />
    /// </summary>
    public class StudentDetails
    {

        /// <summary>
        /// Static field s_studentID used to autoincrement StudentID of the instance of <see cref="StudentDetails" />
        /// </summary>
        private static int s_studentID=3000;
       
        //Auto Property
        /// <summary>
        /// StudentID Property used to hold a Student's ID of the instance of <see cref="StudentDetails" />
        /// </summary>
        public string StudentID {get;}

        /// <summary>
        /// FirtsName Property used to hold FirstName of  of the instance of <see cref="StudentDetails" />
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// FatherName Property used to hold FatherName of the instance of <see cref="StudentDetails" />
        /// </summary>
        public string FatherName { get; set; }

        /// <summary>
        /// DateOfBirth Property used to hold DateOfBirth of the instance of <see cref="StudentDetails" />
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gender Property used to hold Gender of the instance of <see cref="StudentDetails" />
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// PhysicsMarks Property used to hold PhysicsMarks of the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property requires double values from 0-100</value>
        public double PhysicsMarks { get; set; }

        /// <summary>
        /// ChemistryMarks Property used to hold ChemistryMarks of the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property requires double values from 0-100</value>
        public double ChemistryMarks { get; set; }

        /// <summary>
        /// MathsMarks Property used to hold MathsMarks of the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property requires double values from 0-100</value>
        public double MathsMarks { get; set; }

        //Default Constructor
        
       /// <summary>
        /// Constructor StudentDetails used to initialize default values to its properties
        /// </summary>
        public StudentDetails()
        {
            StudentName="Enter your Name";
            FatherName="Enter your father name";
            Gender=Gender.Select;
        }
        //Parametrized Constructor

        /// <summary>
        /// Parametrized StudentDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="studentID">studenID parameter used to assign its values to associated property</param>
        /// <param name="studentName">studentName parameter used to assign its values to associated property</param>
        /// <param name="fatherName">fatherName parameter used to assign its values to associated property</param>
        /// <param name="dateOfBirth">dateOfBirth parameter used to assign its values to associated property</param>
        /// <param name="gender">gender parameter used to assign its values to associated property</param>
        /// <param name="physicsMarks">physicsMarks parameter used to assign its values to associated property</param>
        /// <param name="chemistryMarks">chemistryMarks parameter used to assign its values to associated property</param>
        /// <param name="mathsMarks">mathsMarks parameter used to assign its values to associated property</param>
        public StudentDetails(string studentID,string studentName,string fatherName,DateTime dateOfBirth,Gender gender,double physicsMarks,
        double chemistryMarks,double mathsMarks)
        {
            s_studentID++;
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DateOfBirth=dateOfBirth;
            Gender=gender;
            PhysicsMarks=physicsMarks;
            ChemistryMarks=chemistryMarks;
            MathsMarks=mathsMarks;
        }


        //Methods
        /// <summary>
        /// Method CheckEligibility used to cheeck whether the instance of <see cref="StudentDetails"/>
        /// is eligible for admission based on cutOff
        /// </summary>
        /// <returns>Returns true if eligible, else false.</returns>
        public bool CheckEligibility()
        {
            double average=(PhysicsMarks+ChemistryMarks+MathsMarks)/3.00;
            if(average>75.00)
            {
                System.Console.WriteLine("Your are eligible for the admission.");
                return true;
            }
            else
            {
                System.Console.WriteLine("You are not eligible for the admission.");
                return false;
            }
        
        }

    }
    
}