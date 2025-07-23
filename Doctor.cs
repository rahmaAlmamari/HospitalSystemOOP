using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemOOP
{
    class Doctor : Person
    {
        //1. class Doctor fields ...
        public static int DoctorCount = 0; // Static field to count doctors
        public string Specialization; // Doctor's specialization
        public List<DateTime> AvailableAppointments = new List<DateTime>(); // List of AvailableAppointments for the doctor
        //2. class Doctor properties ...
        //3. class Doctor methods ...
        //to display doctor information ...
        public override string DisplayInfo()
        {
            return ($"Doctor ID: {base.PersonID}\n" +  
                              $"Doctor Name: {base.PersonName}\n" + 
                              $"Doctor Age: {base.PersonAge}\n" +
                              $"Doctor Specialization: {Specialization}\n" +
                              $"-------------------------------------------");
        }
        //to GetPatients ...
        public static bool GetDoctor()
        {
            //to check if there are patient register in the system or not ...
            if (Hospital.HospitalDoctors.Count == 0)
            {
                Console.WriteLine("No doctors register in the system yet.");
                return false;
            }
            return true;
        }
        //to AddPatient ...
        public static void AddDoctors()
        {
            //to create a new doctor object ...
            Doctor newDoctor = new Doctor(Validation.StringNamingValidation("doctor name"),//to get and send the doctor name ...
                                             Validation.IntValidation("doctor age"));//to get and send the doctor age ...
            //to get the doctor specialization ...
            newDoctor.Specialization = Validation.StringValidation("doctor specialization");
            //to get the doctor available appointments ...
            bool flagAvailableAppointments = false; // Flag to control the loop of getting the available appointments ...
            do 
            {
                newDoctor.AvailableAppointments.Add(Validation.DateTimeValidation("doctor available appointments"));
                Console.WriteLine("Do you want to add another available appointment? (Y/N)");
                char choice = Validation.CharValidation("available appointment");
                if (choice == 'Y' || choice == 'y')
                {
                    flagAvailableAppointments = true; // Continue adding appointments
                }
                else
                {
                    flagAvailableAppointments = false; // Stop adding appointments
                }
            } while (flagAvailableAppointments);

            //to store the newDoctor to HospitalDoctors list ...
            Hospital.HospitalDoctors.Add(newDoctor);
            Console.WriteLine("Doctor add successfully with following details:");
            Console.WriteLine(newDoctor.DisplayInfo());
            Additional.HoldScreen();//to hold the screen ...
        }
        //4. class Doctor constructor ...
        public Doctor(string name, int personAge) : base(name, personAge)
        {
            DoctorCount++; // Increment the static count for doctors
            // Doctor specific initialization can go here if needed
        }
    }
}
