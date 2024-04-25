using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //static class
    /// <summary>
    /// Class Operations used to create instance all the operations <see cref="Operations"/>
    /// Refer documentation on <see href="www.syncfusion.com" />
    /// </summary>
    public static class Operations
    {
        /// <summary>
        /// Static field currentLoggedInStudent used to store the logged in student of the instance of <see cref="Operations" />
        /// </summary>
        //Local/Global Object creation
        static StudentDetails currentLoggedInStudent;
        //Static List creation
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("---------------------Welcome to Syncfusion College--------------------");

            string mainChoice = "yes";
            do
            {
                //need to show main menu option
                Console.WriteLine("Mainmenu\n1. Registration\n2. Login\n3. Department wise seat availability\n4. Exit");

                //need to get the input from the user and validate
                Console.Write("Select an option from above: ");
                int mainOption;
                bool tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                while(!tempMainOption)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                }
                //Need to create mainmenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("************Student Registration************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("************Login************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("************Deaprtment wise seat availability************");
                            DeaprtmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application Exited Successfully");
                            mainChoice = "no";
                            break;
                        }
                }
                //Need to iterate until the option is exit
            } while (mainChoice == "yes");
        }//Main menu ends

        //Student Rgistration
        public static void StudentRegistration()
        {
            //Need to get required details
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Father name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Date of birth in DD/MM/YYYY format: ");
            DateTime dob;
            bool tempDate = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
            while(!tempDate)
            {
                System.Console.WriteLine("Invalid input. Enter a valid date");
                tempDate = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
            }
            Console.Write("Enter your gender (Male/Female): ");
            Gender gender;
            bool tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            while(!tempGender)
            {
                System.Console.WriteLine("Invalid Input. Enter a valid Gender");
                tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            }
            Console.Write("Enter your physics marks: ");
            int physics;
            bool tempPhysics = int.TryParse(Console.ReadLine(), out physics);
            while(!tempPhysics)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempPhysics = int.TryParse(Console.ReadLine(), out physics);
            }
            Console.Write("Enter your chemistry marks: ");
            int chemistry;
            bool tempChemistry = int.TryParse(Console.ReadLine(), out chemistry);
            while(!tempChemistry)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempChemistry = int.TryParse(Console.ReadLine(), out chemistry);
            }
            Console.Write("Enter your maths marks: ");
            int maths;
            bool tempMaths = int.TryParse(Console.ReadLine(), out maths);
            while(!tempMaths)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempMaths = int.TryParse(Console.ReadLine(), out maths);
            }

            //Need to create an object
            StudentDetails student = new StudentDetails(name, fatherName, dob, gender, physics, chemistry, maths);

            //Need to add in the list
            studentList.Add(student);

            //Need to display confirmation message and ID.
            Console.WriteLine("Student Registered Successfully and StudentID is " + student.StudentID);
        }//Student registration ends

        //Student Login
        public static void StudentLogin()
        {
            //Need to get ID input
            Console.Write("Enter your StudentID: ");
            string loginID = Console.ReadLine().ToUpper();

            //Validate by its presence in the list.
            bool flag = true;
            foreach (StudentDetails student in studentList)
            {
                if (student.StudentID.Equals(loginID))
                {
                    flag = false;
                    //Assigning current user to global variable
                    currentLoggedInStudent = student;
                    Console.WriteLine("Logged in successfully");
                    //Need to call sub menu
                    SubMenu();
                    break;
                }
            }
            //If not -Invalid
            if (flag)
            {
                Console.WriteLine("Invalid ID or ID iis not present.");
            }
            

        }//Student Login ends

        //Sub Menu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("****************Sub Menu****************");
                //Need to show Sub Menu options 
                Console.WriteLine("Select an Option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Admission Details\n6. Exit");

                //Getting user option
                Console.Write("Enter your option: ");
                int subOption ;
                bool tempSubOption = int.TryParse(Console.ReadLine(),out subOption);
                while(!tempSubOption)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempSubOption = int.TryParse(Console.ReadLine(),out subOption);
                }

                //Need to create sub menu structure
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine("*****************Check Eligibility*****************");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("*****************Show Details*****************");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("*****************Take Admission*****************");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("*****************Cancel Admission*****************");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("*****************Show Admission*****************");
                            AdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("Taking back to MainMenu");
                            subChoice = "no";
                            break;
                        }
                }
                //Iterate till the option is exit.
            } while (subChoice == "yes");
        }//Sub menu ends

        //Check Eligibility
        public static void CheckEligibility()
        {
            //Get the cuttOff value as input
            Console.Write("Enter the cuttoff value: ");
            double cuttOff = double.Parse(Console.ReadLine());

            //Check eligible or not
            if (currentLoggedInStudent.CheckEligibility(cuttOff))
            {
                Console.WriteLine("You are eligible to take admission.");
            }
            else
            {
                Console.WriteLine("You are not eligible.");
            }

        }//CheckEligibility ends

        //Show Dteails
        public static void ShowDetails()
        {
            //Need to show current student's details
            System.Console.WriteLine("|StudentID |Student Name |Father Name |Date of Birth |Gender |Physics Marks |Chemistry Marks |Maths Marks");

            Console.WriteLine($"|{currentLoggedInStudent.StudentID}\t|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB.ToString("dd/MM/yyyy")}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMarks}|{currentLoggedInStudent.ChemistryMarks}|{currentLoggedInStudent.MathsMarks}|");

            System.Console.WriteLine();

        }//Show dteails ends

        //Take admission
        public static void TakeAdmission()
        {
            //Need to show available departments details
            DeaprtmentwiseSeatAvailability();
            //Ask departmentID  from user
            Console.Write("Select a Department ID: ");
            string departmentID = Console.ReadLine().ToUpper();

            //Check the ID is present or not
            bool flag = true;
            foreach (DepartmentDetails department in departmentList)
            {
                if (departmentID.Equals(department.DepartmentID))
                {
                    flag = false;
                    //Check the student is eligible or not
                    if (currentLoggedInStudent.CheckEligibility(75.0))
                    {

                        //Check the seat available or not
                        if (department.NumberOfSeats > 0)
                        {
                            //Check student already taken any admission
                            int count = 0;
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                //Create admission object
                                AdmissionDetails successfullAdmission = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);

                                //Reduce seat count
                                department.NumberOfSeats -= 1;
                                //Add to admission list
                                admissionList.Add(successfullAdmission);
                                //Display admission successful message
                                Console.WriteLine("Admission took successfully. Your admission ID : " + successfullAdmission.AdmissionID);
                            }
                            else
                            {
                                Console.WriteLine("You had already taken the admission");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Seats are not available.");
                        }



                    }
                    else
                    {
                        Console.WriteLine("You are not eligible due to low average.");
                    }

                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }

        }//Take admission ends

        //Cancel admission
        public static void CancelAdmission()
        {
            //Check the student is taken any admission and display it
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(admission.StudentID.Equals(currentLoggedInStudent.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag=false;
                    //Cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to the department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(department.DepartmentID.Equals(admission.DepartmentID))
                        {
                            department.NumberOfSeats+=1;

                            //Display cancelled message
                            Console.WriteLine("Admission Cancelled Successfully.");
                            break;
                        }
                    }
                    break;
                    
                }
            }
            if(flag)
            {
                Console.WriteLine("You did not taken any admission to cancel.");
            }
            
        }//Cancel admission ends

        //Show admission dteails
        public static void AdmissionDetails()
        {
            //Need to show current logged in student admission details
            Console.WriteLine("|AdmissionID|StudentID|DeaprtmentID|Admission Date|Admission Status");
            foreach (AdmissionDetails admission in admissionList)
            {
                if (admission.StudentID.Equals(currentLoggedInStudent.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
                }

            }
        }//Show admission details ends

        //Department wise seat availability
        public static void DeaprtmentwiseSeatAvailability()
        {
            //Need to show all department details
            string line="________________________________________________________";
            System.Console.WriteLine(line);
            Console.WriteLine($"|{"DepartmentID",-13} |{"Department Name",-16} |{"Number of seats",-15}|");
            System.Console.WriteLine(line);
            foreach (DepartmentDetails department in departmentList)
            {
                if (department.NumberOfSeats > 0)
                {
                    Console.WriteLine($"|{department.DepartmentID,-13}|{department.DepartmentName,-16}|{department.NumberOfSeats,-15}|");
                    System.Console.WriteLine(line);
                }
            }
        }//Department wise seat availability

        //Adding deafult data
        public static void AddDefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.AddRange(new List<StudentDetails>() { student1, student2 });


            DepartmentDetails department1 = new DepartmentDetails("EEE ", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE ", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE ", 30);
            departmentList.AddRange(new List<DepartmentDetails>() { department1, department2, department3, department4 });


            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>() { admission1, admission2 });
        }
    }
}