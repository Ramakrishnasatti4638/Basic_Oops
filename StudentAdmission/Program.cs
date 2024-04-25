using System;
namespace StudentAdmission;
class Program 
{
    public static void Main(string[] args)
    {
        //calling create
        FileHandling.Create();
        //Default data calling
        //Operations.AddDefaultData();

        FileHandling.ReadFromCSV();

        //Calling Main Menu
        Operations.MainMenu();

        FileHandling.WriteToCSV();
    }
}