using System;
namespace ValueAndReferenceTypes;
class Proogram 
{
    public static void Main(string[] args)
    {
        int number1=10;
        System.Console.WriteLine(number1);

        int number2=number1;
        System.Console.WriteLine(number2);
        number1=20;
        System.Console.WriteLine(number2);
        number2=number1;
        System.Console.WriteLine(number2);

        Student student=new Student();
        student.Name="Ramakrishna";
        System.Console.WriteLine(student.Name);

        Student student1;
        student1=student;
        System.Console.WriteLine(student1.Name);

        student.Name="reddy";
        System.Console.WriteLine(student.Name);
        System.Console.WriteLine(student1.Name);
    }
}