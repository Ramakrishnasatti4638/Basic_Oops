using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum Gender{Male,Female,Others}
    public class BeneficiaryDetails
    {

        /*
        a.	Registration Number (Auto Incremented BID1001)
        b.	Name
        c.	Age
        d.	Gender (Enum [Male, Female, Others])
        e.	Mobile Number
        f.	City

        */
        //Field
        //static field
        private static int s_registrationNumber=1000;

        //Properties
        public string RegistrationNumber { get; }
        public string BeneficiaryName { get; set; }
        public int BeneficiaryAge { get; set; }
        public Gender BeneficiaryGender { get; set; }
        public string BeneficiaryNumber { get; set; }
        public string BeneficiaryCity { get; set; }

        //Constructor
        public BeneficiaryDetails(string beneficiaryName,int beneficiaryAge,Gender beneficiaryGender,string beneficiaryNumber,string beneficiaryCity)
        {
            //auto increment
            s_registrationNumber++;

            RegistrationNumber="BID"+s_registrationNumber;
            BeneficiaryName=beneficiaryName;
            BeneficiaryAge=beneficiaryAge;
            BeneficiaryGender=beneficiaryGender;
            BeneficiaryNumber=beneficiaryNumber;
            BeneficiaryCity=beneficiaryCity;
        }
        
    }
}