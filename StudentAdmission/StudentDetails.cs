using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
     /// <summary>
    /// DataType Gender used to select a instance of <see cref="StudentDetails"/> Gender Information 
    /// </summary>
    public enum Gender{Select,Male,Female}

     /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails"/>
    /// Refer documentation on <see href="www.syncfusion.com" />
    /// </summary>
    public class StudentDetails
    {
        /*
        a.	StudentName
        b.	FatherName
        c.	DOB
        d.	Gender – Enum (Select, Male, Female, Transgender)
        e.	Physics
        f.	Chemistry
        g.	Maths

        */
        //Field 
        //Static field

        /// <summary>
        /// Static field s_studentID used to autoincrement StudentID of the instance of <see cref="StudentDetails" />
        /// </summary>
        private static int s_studentID=3000;
        //Properties
        /// <summary>
        /// StudentID Property used to hold a Student's ID of the instance of <see cref="StudentDetails" />
        /// </summary>

        public string StudentID { get; } //Read only pproperty

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
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gender Property used to hold Gender of the instance of <see cref="StudentDetails" />
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// PhysicsMarks Property used to hold PhysicsMarks of the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property requires double values from 0-100</value>
        public int PhysicsMarks { get; set; }

         /// <summary>
        /// ChemistryMarks Property used to hold ChemistryMarks of the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property requires double values from 0-100</value>
        public int ChemistryMarks { get; set; }

        /// <summary>
        /// MathsMarks Property used to hold MathsMarks of the instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property requires double values from 0-100</value>
        public int MathsMarks { get; set; }

        //Constructor
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
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender, int physicsMarks,int chemistryMarks,int mathsMarks)
        {
            //Auto Incrementation
            s_studentID++;

            StudentID = "SF" + s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            PhysicsMarks = physicsMarks;
            ChemistryMarks = chemistryMarks;
            MathsMarks = mathsMarks;
        }

        public StudentDetails(string student)
        {
            string[] values=student.Split(",");

            StudentID = values[0];
            s_studentID=int.Parse(values[0].Remove(0,2));
            StudentName = values[1];
            FatherName = values[2];
            DOB = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<Gender>(values[4]);
            PhysicsMarks = int.Parse(values[5]);
            ChemistryMarks = int.Parse(values[6]);
            MathsMarks = int.Parse(values[7]);
        }

        //Methods
        /// <summary>
        /// Method Average used to cheeck whether the instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <returns>Returns double value.</returns>
        public double Average()
        {
            return (double)(PhysicsMarks+ChemistryMarks+MathsMarks)/3.00;
        }

        /// <summary>
        /// Method CheckEligibility used to cheeck whether the instance of <see cref="StudentDetails"/>
        /// is eligible for admission based on cutOff
        /// </summary>
        /// <returns>Returns true if eligible, else false.</returns>
        public bool CheckEligibility(double cuttOff)
        {
            if(Average()>=cuttOff)
            {
                return true;
            }
            return false;
        }
    }
}