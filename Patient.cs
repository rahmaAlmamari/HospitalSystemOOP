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
        public int PhoneNumber;
        public List<Appointment> PatientAppointments = new List<Appointment>(); // List of appointments for the patient
        //2. class Patient properties ...
        //3. class Patient methods ...
        //4. class Patient constructor ...
        public Patient(string name, int personAge) : base(name, personAge)
        {
            PatientCount++; // Increment the static count for patients
            // Patient specific initialization can go here if needed
        }
    }
}
