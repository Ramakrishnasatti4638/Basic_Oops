using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace EbBillCalculation
{
    public class UserDetails
    {
        private static int s_userId=1000;
        public string MeterID { get; set; }
        public string Username { get; set; }
        public string Number { get; set; }
        public string MailID { get; set; }
        public double UnitsUsed { get; set; }


        
        public UserDetails(string userName,string number,string mailID,int unitsUsed=0)
        {
            s_userId++;
            MeterID="EB"+s_userId;
            Username=userName;
            Number=number;
            MailID=mailID;
            UnitsUsed=unitsUsed;
        }


        public void CalculateAmount()
        {
            System.Console.WriteLine("Enter units consumed: ");
            double unitsUsed=double.Parse(Console.ReadLine());
            System.Console.WriteLine("Your MeterID is "+ MeterID);
            System.Console.WriteLine("Your UserName is "+Username);
            System.Console.WriteLine("Units Consumed are: "+unitsUsed);
            System.Console.WriteLine("Bill Amount : "+unitsUsed*5);
        }
    }
}