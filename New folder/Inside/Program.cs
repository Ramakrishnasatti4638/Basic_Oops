using System;
using Outside;
namespace Inside;
class Program 
{
    public static void Main(string[] args)
    {
        First one=new First();
        System.Console.WriteLine(one.publicNumber);
        //System.Console.WriteLine(one.privateNumber);
        System.Console.WriteLine(one.PrivateOut);

        Second two=new Second();
        two.SecondMethond();
        System.Console.WriteLine(one.InternalNumber);
        Third three=new Third();
    }
}