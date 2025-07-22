using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemOOP
{
    class Appointment
    {
        //1. class Appointment fields ...
        public static int AppointmentCount = 0; // Static field to count appointments
        public int AppointmentID; // Unique ID for each appointment
        Doctor AppointmentDoctor; // Doctor for the appointment
        Patient AppointmentPatient; // Patient for the appointment
        DateTime AppointmentDate; // Date and time of the appointment
        //2. class Appointment properties ...
        //3. class Appointment methods ...
        //4. class Appointment constructor ...
        public Appointment()
        {
            AppointmentCount++; // Increment the static count for appointments
            AppointmentID = AppointmentCount; // Assign a unique ID to the appointment
        }
    }
}
