using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public static class Operations
    {

        //local/global object creation
        static BeneficiaryDetails currentLoggedInBeneficiary;

        //Beneficiery List
        static List<BeneficiaryDetails> beneficiaryList = new List<BeneficiaryDetails>();

        //Vaccine List
        static List<VaccineDetails> vaccineList = new List<VaccineDetails>();

        //Vaccination List
        static List<VaccinationDetails> vaccinationList = new List<VaccinationDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("*******************************Welcome to Covid Vaccination*******************************");
            string mainChoice = "yes";
            do
            {
                //need to show the main menu
                Console.WriteLine("Main Menu\n1. Beneficiary Registration\n2. Login\n3. Get Vaccine Info\n4. Exit");

                //need to get the input from the user and validate
                Console.Write("Enter the option from above: ");
                int mainOption = int.Parse(Console.ReadLine());

                //need to create main menu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("*******************************Beneficiary Registration*******************************");
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*******************************Login*******************************");
                            BeneficiaryLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*******************************Vaccine Info*******************************");
                            GetVaccineInfo();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Application exited successfully.");
                            mainChoice = "no";
                            break;
                        }
                }
                //need to iterate until the option is exit

            } while (mainChoice == "yes");
        }//Main menu ends

        //Beneficiary Registration
        public static void BeneficiaryRegistration()
        {
            //need to get required details
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            System.Console.WriteLine("Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter your gender(Male,Female,Others): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.WriteLine("Enter your number: ");
            string number = Console.ReadLine();
            System.Console.WriteLine("Enter your city: ");
            string city = Console.ReadLine();

            //need to create an oject
            BeneficiaryDetails beneficiary = new BeneficiaryDetails(name, age, gender, number, city);
            //need to add in the list
            beneficiaryList.Add(beneficiary);
            //need to display confirmation message and ID
            System.Console.WriteLine("Beneficiary added successfully. Your beneficiary registration number is " + beneficiary.RegistrationNumber);
        }//Beneficiary Registration ends

        //Beneficiary Login
        public static void BeneficiaryLogin()
        {
            //need to get ID input
            System.Console.WriteLine("Enter your registration ID: ");
            string loginID = Console.ReadLine();

            //validate by its presence in the list
            bool flag = true;
            foreach (BeneficiaryDetails beneficiary in beneficiaryList)
            {
                if (beneficiary.RegistrationNumber.Equals(loginID))
                {
                    flag = false;
                    //assigning current user to global
                    currentLoggedInBeneficiary = beneficiary;
                    System.Console.WriteLine("Logged in Successfully");
                    //need to call sub menu
                    SubMenu();
                    break;
                }
            }

            //if not --invalid
            if (flag)
            {
                System.Console.WriteLine("Invalid ID or ID is not present.");
            }
        }//Beneficiary Login ends

        //Sub Menu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("***********************Sub Menu***********************");
                //need to show sub menu
                System.Console.WriteLine("Select an option\n1. Show my details\n2. Take vaccination\n3. My vaccination History\n4. Next Due Date\n5. Exit");

                //Getting user option
                System.Console.WriteLine("Enter your option: ");
                int subOption = int.Parse(Console.ReadLine());
                //need to create sub menu structure
                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("***************Show My Details***************");
                            ShowDetails();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("***************Take Vaccination***************");
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("***************My vaccination History***************");
                            VaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("***************Next Due Date***************");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Going to main menu");
                            subChoice = "no";
                            break;
                        }
                }
                //need to iterate till exit
            } while (subChoice == "yes");
        }// end of sub menu

        //Show my details
        public static void ShowDetails()
        {
            System.Console.WriteLine("|Registration Number|Name|Age|Gender|Mobile Number|City|");

            System.Console.WriteLine($"|{currentLoggedInBeneficiary.RegistrationNumber}|{currentLoggedInBeneficiary.BeneficiaryName}|{currentLoggedInBeneficiary.BeneficiaryAge}|{currentLoggedInBeneficiary.BeneficiaryGender}|{currentLoggedInBeneficiary.BeneficiaryNumber}|{currentLoggedInBeneficiary.BeneficiaryCity}");

        }//end of show details

        //Take vaccination
        public static void TakeVaccination()
        {
            //need to show available vaccines
            GetVaccineInfo();
            //ask vaccine id from the user 
            System.Console.WriteLine("Enter the vaccine ID you want: ");
            string vaccineID = Console.ReadLine();

            //Check id is present or not
            bool flag = true;
            bool isSame = false;
            foreach (VaccineDetails vaccine in vaccineList)
            {
                if (vaccine.VaccineID.Equals(vaccineID))
                {
                    flag = false;
                    //get the vaccination history of current logged in user
                    if (vaccine.NoOfDoseAvailable > 0)
                    {
                        int count = 0;
                        foreach (VaccinationDetails vaccination in vaccinationList)
                        {
                            if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                            {
                                count++;
                            }
                        }
                        foreach (VaccinationDetails vaccination in vaccinationList)
                        {

                            if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                            {
                                if (count == 0)
                                {
                                    //if he did not take any vaccine check if his age is above 14
                                    if (currentLoggedInBeneficiary.BeneficiaryAge > 14)
                                    {
                                        //if yes allow to take vaccine 
                                        System.Console.WriteLine("You are allowed to take vaccine");

                                        //update the details in vaccination history
                                        VaccinationDetails newVaccine = new VaccinationDetails(currentLoggedInBeneficiary.RegistrationNumber, vaccine.VaccineID, 1, DateTime.Now);
                                        vaccinationList.Add(newVaccine);
                                        //deduct the count of vaccine available
                                        vaccine.NoOfDoseAvailable -= 1;
                                        //if vaccination history he took 3 doses display message
                                        //if one or two vaccines taken
                                        //find the vaccine selected is same type or not
                                        //if yes check date of last vaccination and find 30 days completed or not
                                        //if yes allow to take vaccine
                                        //add details in vaccine list
                                        //deduct the vaccine
                                        //if not display message
                                    }

                                    else
                                    {
                                        System.Console.WriteLine("You should be abive 14 to take vaccine.");
                                        break;
                                    }

                                }
                                else if (count == 3)
                                {
                                    //if vaccination history he took 3 doses display message
                                    System.Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                                    break;

                                }
                                //if one or two vaccines taken
                                else if (count == 1)
                                {

                                    //find the vaccine selected is same type or not

                                    if (vaccine.VaccineID.Equals(vaccination.VaccineID) && currentLoggedInBeneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                                    {
                                        isSame = true;
                                        //if yes check date of last vaccination and find 30 days completed or not
                                        DateTime lastVaccinatedDate = vaccination.VaccinatedDate;
                                        DateTime today = DateTime.Now;
                                        TimeSpan span = today - lastVaccinatedDate;
                                        if (span.Days > 30)
                                        {
                                            //if yes allow to take vaccine
                                            int numberOfDoses = count + 1;
                                            VaccinationDetails newVaccine = new VaccinationDetails(currentLoggedInBeneficiary.RegistrationNumber, vaccine.VaccineID, numberOfDoses, DateTime.Now);

                                            //add details in vaccine list
                                            vaccinationList.Add(newVaccine);
                                            //deduct the vaccine
                                            vaccine.NoOfDoseAvailable -= 1;
                                            break;
                                        }


                                    }
                                    else
                                    {
                                        if (vaccine.VaccineName.Equals("Covaccine"))
                                        {
                                            System.Console.WriteLine("You had selected different vaccine you can select Covishield");
                                            break;
                                        }
                                        else
                                        {
                                            if (vaccine.VaccineName.Equals("Covaccine"))
                                            {
                                                System.Console.WriteLine("You had selected different vaccine you can select Covaccine");
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (count == 2)
                                {

                                    //find the vaccine selected is same type or not

                                    if (vaccine.VaccineID.Equals(vaccination.VaccineID) && currentLoggedInBeneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                                    {
                                        isSame = true;
                                        //if yes check date of last vaccination and find 30 days completed or not
                                        DateTime lastVaccinatedDate = vaccination.VaccinatedDate;
                                        DateTime today = DateTime.Now;
                                        TimeSpan span = today - lastVaccinatedDate;
                                        if (span.Days > 30)
                                        {
                                            //if yes allow to take vaccine
                                            int numberOfDoses = count + 1;
                                            VaccinationDetails newVaccine = new VaccinationDetails(currentLoggedInBeneficiary.RegistrationNumber, vaccine.VaccineID, numberOfDoses, DateTime.Now);

                                            //add details in vaccine list
                                            vaccinationList.Add(newVaccine);
                                            //deduct the vaccine
                                            vaccine.NoOfDoseAvailable -= 1;
                                            System.Console.WriteLine("Vaccinated");
                                            break;
                                        }


                                    }
                                    else
                                    {
                                        if (vaccine.VaccineName.Equals(vaccineList[1].VaccineName))
                                        {
                                            System.Console.WriteLine("You had selected different vaccine you can select Covishield");
                                            break;
                                        }
                                        else
                                        {
                                            if (vaccine.VaccineName.Equals(vaccineList[0].VaccineName))
                                            {
                                                System.Console.WriteLine("You had selected different vaccine you can select Covaccine");
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        // if (!isSame)
                        // {

                        //     System.Console.WriteLine("Invalid input");
                        // }
                    }
                    else
                    {
                        System.Console.WriteLine("No vaccines available.");
                    }
                }

            }
            if (flag)
            {
                System.Console.WriteLine("Invalid vaccine ID");
            }


        }//end of take vaccination

        //Vaccination History
        public static void VaccinationHistory()
        {
            //Need to show current logged in user vaccine histolry
            int count = 0;
            foreach (VaccinationDetails vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                System.Console.WriteLine("You did not vaccinaated. Vacinate first.");
                return;
            }
            foreach (VaccinationDetails vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    System.Console.WriteLine($"|{vaccination.VaccinationID}|{vaccination.RegistrationNumber}|{vaccination.VaccineID}|{vaccination.DoseNumber}|{vaccination.VaccinatedDate.ToString("dd/MM/yyyy")}");
                }
            }
        }//end of vaccination history

        //Next due date
        public static void NextDueDate()
        {
            int count = 0;
            //get the details from vaccinatio history
            foreach (VaccinationDetails vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    count++;
                }
            }
            foreach (VaccinationDetails vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    //if he didnot take any dose display message
                    if (count == 0)
                    {
                        System.Console.WriteLine("You can take vaccine now.");
                        break;
                    }
                    //if either first or second completed add 30 days to find next due data
                    else if (count == 1)
                    {
                        if (vaccination.DoseNumber == 1)
                        {
                            DateTime lastVaccineDate = vaccination.VaccinatedDate;
                            DateTime newVaccineDate = lastVaccineDate.AddDays(30);
                            System.Console.WriteLine("Your next due date is :" + newVaccineDate.ToString("dd/MM/yyyy"));
                            break;
                        }
                    }
                    else if (count == 2)
                    {
                        if (vaccination.DoseNumber == 2)
                        {
                            DateTime lastVaccineDate = vaccination.VaccinatedDate;
                            DateTime newVaccineDate = lastVaccineDate.AddDays(30);
                            System.Console.WriteLine("Your next due date is :" + newVaccineDate.ToString("dd/MM/yyyy"));
                            break;
                        }
                    }
                    else if (count == 3)
                    {
                        System.Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.”");
                        break;
                    }
                }
            }


            //if 3rd dose completed display message
        }//end of next due date

        //Getu vaccine info
        public static void GetVaccineInfo()
        {
            //need to show all vaccines
            int count = 0;
            foreach (VaccineDetails vaccine in vaccineList)
            {
                if (vaccine.NoOfDoseAvailable > 0)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                System.Console.WriteLine("|vaccineID |VaccineName |NoofDosesAvailable");
                foreach (VaccineDetails vaccine in vaccineList)
                {
                    if (vaccine.NoOfDoseAvailable > 0)
                    {
                        System.Console.WriteLine($"|{vaccine.VaccineID} |{vaccine.VaccineName} |{vaccine.NoOfDoseAvailable}");
                    }
                }
            }

        }//Get vaccine info ends

        //adding Default values to the list
        public static void DefaultValues()
        {
            BeneficiaryDetails beneficiary1 = new BeneficiaryDetails("Ravichandran", 21, Gender.Male, "8484484", "Chennai");
            BeneficiaryDetails beneficiary2 = new BeneficiaryDetails("Baskaran", 22, Gender.Male, "8484747", "Chennai");
            beneficiaryList.AddRange(new List<BeneficiaryDetails>() { beneficiary1, beneficiary2 });

            VaccineDetails vaccine1 = new VaccineDetails(VaccineName.Covishield, 50);
            VaccineDetails vaccine2 = new VaccineDetails(VaccineName.Covaccine, 50);
            vaccineList.AddRange(new List<VaccineDetails>() { vaccine1, vaccine2 });

            VaccinationDetails vaccination1 = new VaccinationDetails(beneficiary1.RegistrationNumber, vaccine1.VaccineID, 1, new DateTime(2021, 11, 11));
            VaccinationDetails vaccination2 = new VaccinationDetails(beneficiary1.RegistrationNumber, vaccine1.VaccineID, 2, new DateTime(2022, 03, 11));
            VaccinationDetails vaccination3 = new VaccinationDetails(beneficiary2.RegistrationNumber, vaccine2.VaccineID, 1, new DateTime(2022, 04, 04));
            vaccinationList.AddRange(new List<VaccinationDetails>() { vaccination1, vaccination2, vaccination3 });
        }
    }
}