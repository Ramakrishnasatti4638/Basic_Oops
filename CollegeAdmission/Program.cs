using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace CollegeAdmission;
class Program 
{
    
    public static void Main(string[] args)
    {


        List<StudentDetails> studentList=new List<StudentDetails>();
        string option="";
        do
        {
            System.Console.WriteLine("Student Registration Form");
            //Default Constructor example
            // StudentDetails student1=new StudentDetails();
            // System.Console.WriteLine("Enter your name: ");
            // student1.StudentName=Console.ReadLine();
            
            // System.Console.WriteLine("Enter your father name: ");
            // student1.FatherName=Console.ReadLine();
            
            
            // System.Console.WriteLine("Enter your gender: ");
            // student1.Gender=Console.ReadLine();
            
            // System.Console.WriteLine("Enter your date of birth (dd/MM/yyyy): ");
            // student1.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            // System.Console.WriteLine("Enter your phone number: ");
            // student1.Phone=long.Parse(Console.ReadLine());

            // System.Console.WriteLine("Enter your physics marks: ");
            // student1.Physics=int.Parse(Console.ReadLine());

            // System.Console.WriteLine("Enter your chemistry marks: ");
            // student1.Chemistry=int.Parse(Console.ReadLine());

            // System.Console.WriteLine("Enter your Maths marks: ");
            // student1.Maths=int.Parse(Console.ReadLine());

            // studentList.Add(student1);
            //StudentDetails student1=new StudentDetails();


            //Parametrized constructor example
            System.Console.WriteLine("Enter your name: ");
            string studentName=Console.ReadLine();
            
            System.Console.WriteLine("Enter your father name: ");
            string fatherName=Console.ReadLine();
            
            
            System.Console.WriteLine("Enter your gender (Male, Female, Transgender): ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine());
            
            System.Console.WriteLine("Enter your date of birth (dd/MM/yyyy): ");    
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            System.Console.WriteLine("Enter your phone number: ");
            long phone=long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your physics marks: ");
            int physics=int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your chemistry marks: ");
            int chemistry=int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your Maths marks: ");
            int maths=int.Parse(Console.ReadLine());

            StudentDetails student=new StudentDetails(studentName,fatherName,gender,dob,phone,physics,chemistry,maths);
            studentList.Add(student);
            System.Console.WriteLine("Your Student Id is "+student.StudentID);

            System.Console.WriteLine("do you want to continue");
            option=Console.ReadLine();
            
        }while(option=="yes");
        

        System.Console.WriteLine("Enter your student id to login: ");
        string loginID=Console.ReadLine().ToUpper();
        bool flag=true;
        foreach(StudentDetails student in studentList)
        {
            if(student.StudentID==loginID)
            {
                flag=false;
                System.Console.WriteLine("Name : "+student.StudentName+"\nYour father name : "+student.FatherName+"\nyour dob is "
                +student.DOB.ToString("dd/MM/yyyy"));
                System.Console.WriteLine("Your gender is : "+student.Gender);
                System.Console.WriteLine("your mobile number is : "+student.Phone);
                System.Console.WriteLine("Your physics marks are : "+student.Physics);
                System.Console.WriteLine("Your chemistry marks are : "+student.Chemistry);
                System.Console.WriteLine("Your maths marks are : "+student.Maths);

                bool eligibility=student.CheckEligiblity(75);
                if(eligibility)
                {

                    System.Console.WriteLine("eligible");
                }
                else
                {
                    System.Console.WriteLine("Not eligible");
                }
            }
        
            
            
        }
        if(flag)
        {
                System.Console.WriteLine("Invalid user ID");
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        
    }
}