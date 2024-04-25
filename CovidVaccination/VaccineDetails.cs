using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum VaccineName{Covishield, Covaccine}
    public class VaccineDetails
    {
        /*
        a.	VaccineID {Auto Incremented ID – CID2001}
        b.	VaccineName {Enum – Covishield, Covaccine}
        c.	NoOfDoseAvailable

        */

        //Field
        //Static field
        private static int s_vaccineID=2000;

        //properties
        public string VaccineID { get; }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        //Constructor
        public VaccineDetails(VaccineName vaccineName,int noOfDoseAvailable)
        {
            //auto increment
            s_vaccineID++;

            VaccineID="CID"+s_vaccineID;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
    }
}