using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class VaccinationDetails
    {
        /*
            •	VaccinationID (Auto increment – VID3001)
            •	Registration Number (Beneficiary Reg. num)
            •	VaccineID
            •	DoseNumber – (1,2,3)
            •	Vaccinated Date (DateTime.Now)

        */

        //Field
        //Static Field
        private static int s_vaccinationID=3000;

        //Properties
        public string VaccinationID { get;  }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }

        //Constructor
        public VaccinationDetails(string registrationNumber,string vaccineID,int doseNumber,DateTime vaccinatedDate)
        {
            //auto increment
            s_vaccinationID++;

            VaccinationID="VID"+s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedDate;
        }
    }
}