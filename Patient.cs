using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemOOP
{
    class Patient : Person
    {
        //1. class Patient fields ...
        public static int PatientCount = 0; // Static field to count patients
        public int PatientPhoneNumber;
        //2. class Patient properties ...
        public int P_PatientPhoneNumber
        {
            get { return PatientPhoneNumber; }
            set
            {
                bool FalgError = false; //to handle the error ...
                do
                {
                    FalgError = false; //to reset the error flag ...
                    //to check if the phone number is 8 digits or not ...
                    if (value.ToString().Length == 8)
                    {
                        PatientPhoneNumber = value;
                    }
                    else
                    {
                        Console.WriteLine("Phone number must be 8 digits.");
                        value = Validation.IntValidation("patient phone number");
                        FalgError = true; //to handle the error ...
                    }

                } while (FalgError);

            }
        }
        //3. class Patient methods ...
        //to display patient information ...
        public override string DisplayInfo()
        {
            return ($"Patient ID: {base.PersonID}\n" +
                              $"Patient Name: {base.PersonName}\n" +
                              $"Patient Age: {base.P_Age}\n" +
                              $"Patient Phone Number: {P_PatientPhoneNumber}\n" +
                              $"--------------------------------------------");
        }
        //to GetPatients ...
        public static bool GetPatients()
        {
            //to check if there are patient register in the system or not ...
            if (Hospital.HospitalPatients.Count == 0)
            {
                Console.WriteLine("No patient register in the system yet.");
                return false;
            }
            return true;
        }
        //to AddPatient ...
        public static void AddPatient()
        {
            //to create a new patient object ...
            Patient newPatient = new Patient(Validation.StringNamingValidation("patient name"),//to get and send the patient name ...
                                             Validation.IntValidation("patient age"));//to get and send the patient age ...
            //to get the patient phone number ...
            newPatient.P_PatientPhoneNumber = Validation.IntValidation("patient phone number");
            //to store the newpatient to HospitalPatients list ...
            Hospital.HospitalPatients.Add(newPatient);
            Console.WriteLine("Patient add successfully with following details:");
            Console.WriteLine(newPatient.DisplayInfo());
            Additional.HoldScreen();//to hold the screen ...
        }
        //to GetPatientsList ...
        public static void GetPatientsList()
        {
            //to check if there are patients in the system or not ...
            if (!GetPatients())
            {
                return; // Exit if no patients are available
            }
            //to display the list of patients ...
            Console.WriteLine("List of Patients:");
            foreach (var patient in Hospital.HospitalPatients)
            {
                Console.WriteLine( patient.DisplayInfo());
            }
        }
        // to GetPatientByID ...
        public static Patient GetPatientByID(int id)
        {
            //to check if there are patients in the system or not ...
            if (!GetPatients())
            {
                return null; // Exit if no patients are available
            }
            //to find the patient by ID ...
            return Hospital.HospitalPatients.FirstOrDefault(p => p.PersonID == id);
        }
        //4. class Patient constructor ...
        public Patient(string name, int personAge) : base(name, personAge)
        {
            PatientCount++; // Increment the static count for patients
            // Patient specific initialization can go here if needed
        }
    }
}
