using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace CollegeStudentAdmission;
class Program 
{
    static List<StudentDetails> studentDetailsList=new List<StudentDetails>();
    static List<DepartmentDetails> departmentsList=new List<DepartmentDetails>();
    static List<AdmissionDetails> admissionList=new List<AdmissionDetails>();

    static bool isSet=true;

    public static void Main(string[] args)
    {
         string mainMenu="";
         DefaultValues();       //Method for default values in the list
         System.Console.WriteLine("                      Welcome To Syncfusion College");

         do
         {
            
            Console.WriteLine("-----------------------------------Main Menu---------------------------------");
            Console.WriteLine("1. Student Registration");
            Console.WriteLine("2. Student Login");
            Console.WriteLine("3. Department wise seat availability");
            Console.WriteLine("4. Exit");
            System.Console.WriteLine("Enter your option number from above list: ");
            int mainMenuOption=int.Parse(Console.ReadLine());
            switch (mainMenuOption)         //Switch for getting into the methods
            {
                case 1:
                {
                    Registration();         //student registration 
                    System.Console.WriteLine("Do you want to continue: ");
                    mainMenu=Console.ReadLine();
                    
                    break;
                }
                case 2:
                {
                    Login();            //student login
                    if(isSet)
                    {
                        System.Console.WriteLine("Do you want to continue: ");
                        mainMenu=Console.ReadLine();
                    }
                    mainMenu="yes";
                    break;
                }
                case 3:
                {
                    SeatAvailability();     //to check the number of seats available
                    System.Console.WriteLine("Do you want to continue: ");
                    mainMenu=Console.ReadLine();
                    break;
                }
                case 4:
                {
                    Environment.Exit(0);        //to close the application
                    break;
                }
            }
        } while (mainMenu=="yes");   
    }

    public static void DefaultValues()
    {
        // Default values into the lists
        DateTime dateOfBirth;
        DateTime.TryParse("11/11/1999",null,out dateOfBirth);
        Gender gender;
        Enum.TryParse<Gender>("Male",true,out gender);
        StudentDetails student=new StudentDetails("","Ravichandran E","Ettaparajan",dateOfBirth,gender,95,95,95);
        studentDetailsList.Add(student);
        
        DateTime dateOfBirth1;
        DateTime.TryParse("11/11/1999",null,out dateOfBirth1);
        Gender gender1;
        Enum.TryParse<Gender>("Male",true,out gender1);
       
        StudentDetails student1=new StudentDetails("","Baskaran S","Sethurajan",dateOfBirth1,gender1,95,95,95);
        studentDetailsList.Add(student1);
        
        DepartmentDetails department=new DepartmentDetails("","EEE ",29);
        departmentsList.Add(department);
       
        DepartmentDetails department1=new DepartmentDetails("","CSE ",29);
        departmentsList.Add(department1);
       
        DepartmentDetails department2=new DepartmentDetails("","MECH",30);
        departmentsList.Add(department2);
        
        DepartmentDetails department3=new DepartmentDetails("","ECE ",30);
        departmentsList.Add(department3);
        string admissionID="";
        string studentID1st=student.StudentID;
        string departmentID1st=department.DepartmentID;
        DateTime admissionDate;
        DateTime.TryParse("11/05/2022",null,out admissionDate);
        string admissionStatus="Booked";
        AdmissionDetails admission=new AdmissionDetails(admissionID,studentID1st,departmentID1st,admissionDate,admissionStatus);
        admissionList.Add(admission);
        string admissionID1="";
        string studentID2nd=student1.StudentID;
        string departmentID2nd=department1.DepartmentID;
        DateTime admissionDate1;
        DateTime.TryParse("11/05/2022",null,out admissionDate1);
        string admissionStatus1="Booked";
        AdmissionDetails admission1=new AdmissionDetails(admissionID1,studentID2nd,departmentID2nd,admissionDate1,admissionStatus1);
        admissionList.Add(admission1);
    }

    public static void Registration()
    {

        // Student Registration
        string studentID="";
        System.Console.WriteLine("Enter your Name: ");
        string studentName=Console.ReadLine();
        System.Console.WriteLine("Enter your Father Name: ");
        string fatherName=Console.ReadLine();
        System.Console.WriteLine("Enter your Date of Birth: ");
        DateTime dateOfBirth;
        bool isDateValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dateOfBirth);
        while(!isDateValid)
        {
            System.Console.WriteLine("Entered date is not in correct format\nPlease reenter date in (dd/MM/yyyy) format");
            isDateValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dateOfBirth);
        }
        System.Console.WriteLine("Enter your Gender (Male, Female, Transgender)");
        Gender gender;
        bool isGenderValid=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        while(!isGenderValid)
        {
            System.Console.WriteLine("Entered data is wrong\nPlease try again");
            isGenderValid=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        }
        System.Console.WriteLine("Enter your Physics marks: ");
        double physicsMarks=double.Parse(Console.ReadLine());   
        System.Console.WriteLine("Enter your Chemistry marks: ");
        double chemistryMarks=double.Parse(Console.ReadLine());
        System.Console.WriteLine("Enter your Maths marks: ");
        double mathsMarks=double.Parse(Console.ReadLine());

        StudentDetails student=new StudentDetails(studentID,studentName,fatherName,dateOfBirth,gender,physicsMarks,chemistryMarks,mathsMarks);
        studentDetailsList.Add(student);
        System.Console.WriteLine("Student Registered Successfully and StudentID is "+student.StudentID);


    }

    public static void Login()
    {

        //Student Login
        System.Console.WriteLine("Enter your StudentID: ");
        string studentID=Console.ReadLine().ToUpper();
        StudentDetails student=studentDetailsList.Find(x=>x.StudentID==studentID);
        if(student==null)
        {
            System.Console.WriteLine("Invalid User id");
            return;
        }
        do
        {
            System.Console.WriteLine("---------------Sub Menu---------------");
            System.Console.WriteLine("a. Check Eligibility");
            System.Console.WriteLine("b. Show Details");
            System.Console.WriteLine("c. Take Admission");
            System.Console.WriteLine("d. Cancel Admission");
            System.Console.WriteLine("e. Show Admission Details");
            System.Console.WriteLine("f. Exit");
            System.Console.WriteLine("Enter your option from above ");
            char subMenuOption=char.Parse(Console.ReadLine());
            switch(subMenuOption)
            {
                case 'a':
                {
                    student.CheckEligibility();
                    isSet=true;
                    break;
                }
                case 'b':
                {
                    ShowDetails(student);
                    isSet=true;
                    break;
                }
                case 'c':
                {
                    TakeAdmission(student);
                    isSet=true;
                    break;
                }
                case 'd':
                {
                    CancelAdmission(student);
                    isSet=true;
                    break;
                }
                case 'e':
                {
                    ShowAdmissionDetails(student);
                    isSet=true;
                    break;
                }
                case 'f':
                {
                    isSet=false;
                    return;
                }
            }
        } while (true);
    }

    public static void SeatAvailability()
    {

        //To check the number of seats available in the departments
        System.Console.WriteLine("No of seats available in each department are");
        System.Console.WriteLine("DepeartmentID      Department Name      Number of seats left");
        foreach(DepartmentDetails values in departmentsList)
        {
            System.Console.WriteLine($"{values.DepartmentID}                 {values.DepartmentName}                {values.NumberOfSeats}");
        }
    }

    public static void ShowDetails(StudentDetails student)
    {

        //To print the details of the student
        System.Console.WriteLine("StudentID: "+student.StudentID);
        System.Console.WriteLine("Student Name: "+student.StudentName);
        System.Console.WriteLine("Father Name: "+student.FatherName);
        System.Console.WriteLine("Date of Birth: "+student.DateOfBirth.ToString("dd/MM/yyyy"));
        System.Console.WriteLine("Gender: "+student.Gender);
        System.Console.WriteLine("Physics Marks: "+student.PhysicsMarks);
        System.Console.WriteLine("Chemistry Marks: "+student.ChemistryMarks);
        System.Console.WriteLine("Maths Marks: "+student.MathsMarks);

    }

    public static void TakeAdmission(StudentDetails student)
    {
        //Method to take the admission for the student
        System.Console.WriteLine("List of available departments and seats left.");
        System.Console.WriteLine("DepeartmentID      Department Name      Number of seats left");
        foreach(DepartmentDetails values in departmentsList)
        {
            System.Console.WriteLine($"{values.DepartmentID}                 {values.DepartmentName}                {values.NumberOfSeats}");
        }
        System.Console.WriteLine("Enter the DepartmentID you want to take: ");
        string departmentID=Console.ReadLine();
        DepartmentDetails department=departmentsList.Find(x=>x.DepartmentID==departmentID);
        if(department==null)
        {
            System.Console.WriteLine("Department ID is invalid. Please Try again");
            return;
        }
        bool isEligible=student.CheckEligibility();
        if(!isEligible)
        {
            return;
        }
        if(department.NumberOfSeats<=0)
        {
            System.Console.WriteLine($"The seats of {department.DepartmentName} has been totally field please select other departments. ");
            return;
        }
        foreach(AdmissionDetails admission in admissionList)
        {
        //AdmissionDetails admission=admissionList.Find(x=>x.StudentID==student.StudentID);
            if(admission.AdmissionStatus=="Booked" && admission.StudentID==student.StudentID)
            {
                System.Console.WriteLine("You had already taken the admission.");
                return;
            }
        }
        department.NumberOfSeats-=1;
        AdmissionDetails newAdmission=new AdmissionDetails("",student.StudentID,department.DepartmentID,DateTime.Now,"Booked");
        admissionList.Add(newAdmission);
        System.Console.WriteLine("Admission took successfully. Your admission ID : "+ newAdmission.AdmissionID);


    }

    
    public static void CancelAdmission(StudentDetails student)
    {
        // Method to cancel the admission of the student 
        AdmissionDetails admission=admissionList.Find(x=>x.StudentID==student.StudentID);
        if(admission==null)
        {
            System.Console.WriteLine("You had not taken admission.");
            return;
        }
        foreach(AdmissionDetails newAdmmision in admissionList)
        {
            if(newAdmmision.AdmissionStatus=="Booked" && newAdmmision.StudentID==student.StudentID)
            {
                newAdmmision.AdmissionStatus="Cancelled";
                DepartmentDetails department=departmentsList.Find(x=>x.DepartmentID==newAdmmision.DepartmentID);
                department.NumberOfSeats+=1;
                //admissionList.Remove(admission);
                System.Console.WriteLine("Admission cancelled succesfully.");
            }
            
        }
        // admission.AdmissionStatus="Cancelled";
        // DepartmentDetails department=departmentsList.Find(x=>x.DepartmentID==admission.DepartmentID);
        // department.NumberOfSeats+=1;
        // //admissionList.Remove(admission);
        // System.Console.WriteLine("Admission cancelled succesfully.");

    }

    public static void ShowAdmissionDetails(StudentDetails student)
    {
        //Method to print the admission details of the student
        AdmissionDetails admission=admissionList.Find(x=>x.StudentID==student.StudentID);
        if(admission==null)
        {
            System.Console.WriteLine("You did not taken any admission. Please take the admission and check.");
            return;
        }
        System.Console.WriteLine("AdmissionID   StudentID   DepartmentID   AdmissionDate   AdmissionStatus");
        
        foreach(AdmissionDetails admissionNew in admissionList)
        {
            if(admissionNew.StudentID==student.StudentID)
            {
                System.Console.WriteLine($"{admissionNew.AdmissionID}        {admissionNew.StudentID}       {admissionNew.DepartmentID}        {admissionNew.AdmissionDate.ToString("dd/MM/yyyy")}       {admissionNew.AdmissionStatus}");
            }
        }
       
    }


    
}