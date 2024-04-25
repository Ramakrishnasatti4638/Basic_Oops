using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender {Select, Male, Female, Transgender}
    public class StudentDetails
    {
        //FIELD
        //private string _studentName;
        private static int s_studentID=1000;

        //PROPERTIES
        //OLD METHOD
        // public string StudentName
        // {
        //     get
        //     {return _studentName;}
        //     set
        //     {_studentName=value;}
        // }

        //AUTOPROPERTY
        //NEW METHOD
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName{get; set;}

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }
        public long Phone { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }





        //CONSTRUCTORS
        //Default Constructor
        public StudentDetails()
        {
            StudentName="Enter Your Name: ";
            FatherName="Enter your Ftaher Name: ";
            Gender=Gender.Select;
        }

        //Paramaterized Constructor
        public StudentDetails(string studentName,string fatherName,Gender gender,DateTime dob, long phone,
        int physics,int chemistry,int maths)
        {
            s_studentID++;
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            Gender=gender;
            DOB=dob;
            Phone=phone;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }


        //Destructors
        ~StudentDetails()
        {
            System.Console.WriteLine("Destructor called.");
        }

        //METHODS
        public bool CheckEligiblity(double cutOff)
        {
            double average=(Physics+Chemistry+Maths)/3.00;
            if(average>=cutOff)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}