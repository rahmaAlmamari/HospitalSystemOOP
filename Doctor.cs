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
        public override void DisplayInfo()
        {
            Console.WriteLine($"Doctor ID: {base.PersonID}\n" +  
                              $"Doctor Name: {base.PersonName}\n" + 
                              $"Doctor Age: {base.PersonAge}\n" +
                              $"Doctor Specialization: {Specialization}");
        }
        //4. class Doctor constructor ...
        public Doctor(string name, int personAge) : base(name, personAge)
        {
            DoctorCount++; // Increment the static count for doctors
            // Doctor specific initialization can go here if needed
        }
    }
}
