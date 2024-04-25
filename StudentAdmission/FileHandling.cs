using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("StudentAdmission"))
            {
                System.Console.WriteLine("Creating folder..");
                Directory.CreateDirectory("StudentAdmission");
            }

            //File for student details
            if (!File.Exists("StudentAdmission/StudentDetails.csv"))
            {
                System.Console.WriteLine("Creating file..");
                File.Create("StudentAdmission/StudentDetails.csv").Close();
            }
            //File for department
            if (!File.Exists("StudentAdmission/DepartmentDetails.csv"))
            {
                System.Console.WriteLine("Creating file..");
                File.Create("StudentAdmission/DepartmentDetails.csv").Close();
            }
            //File for Admission
            if (!File.Exists("StudentAdmission/AdmissionDetails.csv"))
            {
                System.Console.WriteLine("Creating file..");
                File.Create("StudentAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //Students info
            string[] students = new string[Operations.studentList.Count];
            for (int i = 0; i < Operations.studentList.Count; i++)
            {
                students[i] = Operations.studentList[i].StudentID + "," + Operations.studentList[i].StudentName + "," + Operations.studentList[i].FatherName + "," + Operations.studentList[i].DOB.ToString("dd/MM/yyyy") + "," + Operations.studentList[i].Gender + "," + Operations.studentList[i].PhysicsMarks + "," + Operations.studentList[i].ChemistryMarks + "," + Operations.studentList[i].MathsMarks;
            }
            File.WriteAllLines("StudentAdmission/StudentDetails.csv", students);

            //Departments details
            string[] departments = new string[Operations.departmentList.Count];
            for (int i = 0; i < Operations.departmentList.Count; i++)
            {
                departments[i] = Operations.departmentList[i].DepartmentID + "," + Operations.departmentList[i].DepartmentName + "," + Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("StudentAdmission/DepartmentDetails.csv", departments);

            //Admission details
            string[] admissions = new string[Operations.admissionList.Count];
            for (int i = 0; i < Operations.admissionList.Count; i++)
            {
                admissions[i] = Operations.admissionList[i].AdmissionID + "," + Operations.admissionList[i].StudentID + "," + Operations.admissionList[i].DepartmentID + "," + Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy") + "," + Operations.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("StudentAdmission/AdmissionDetails.csv", admissions);
        }

        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("StudentAdmission/StudentDetails.csv");
            foreach (string student in students)
            {
                StudentDetails student1 = new StudentDetails(student);
                Operations.studentList.Add(student1);   
            }

            string[] departments = File.ReadAllLines("StudentAdmission/DepartmentDetails.csv");
            foreach (string department in departments)
            {
                DepartmentDetails department1 = new DepartmentDetails(department);
                Operations.departmentList.Add(department1);
            }

            string[] admissions = File.ReadAllLines("StudentAdmission/AdmissionDetails.csv");
            foreach (string admission in admissions)
            {
                AdmissionDetails admission1 = new AdmissionDetails(admission);
                Operations.admissionList.Add(admission1);
            }
        }
    }
}