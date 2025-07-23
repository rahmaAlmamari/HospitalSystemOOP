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
        //to GetAppointment ...
        public static bool GetAppointment()
        {
            //to check if there are appointments in the system or not ...
            if (Hospital.HospitalAppointments.Count == 0)
            {
                Console.WriteLine("No appointments registered in the system yet.");
                return false;
            }
            return true;
        }
        //to DisplayAppointment ...
        public string DisplayAppointment()
        {
            return ($"Appointment ID: {AppointmentID}\n" +
                               $"Doctor: {AppointmentDoctor.PersonName}\n" +
                               $"Patient: {AppointmentPatient.PersonName}\n" +
                               $"Date and Time: {AppointmentDate.ToString("g")}\n" +
                               $"-------------------------------------------");
        }
        //to BookAppointment ...
        public static void BookAppointment()
        {
            //to check if there are doctors in the system or not ...
            if (!Doctor.GetDoctor())
            {
                return; // Exit if no doctors are available
            }
            //to check if there are patients in the system or not ...
            if (!Patient.GetPatients())
            {
                return; // Exit if no patients are available
            }
            //to create a new appointment object ...
            Appointment newAppointment = new Appointment();
            //to list the available doctors ...
            Doctor.GetDoctorList();
            //to get the doctor for the appointment ...
            bool flagDoctor = false; // Flag to control the loop of getting the doctor ...
            do 
            {
                flagDoctor = false; // Reset the flag for the loop
                newAppointment.AppointmentDoctor = Doctor.GetDoctorByID(Validation.IntValidation("doctor ID for the appointment"));
                if (newAppointment.AppointmentDoctor == null)
                {
                    Console.WriteLine("Invalid doctor ID. Please try again.");
                    flagDoctor = true; // Set the flag to true to repeat the loop
                }
            }while (flagDoctor);
            //to list the available patients ...
            Patient.GetPatientsList();
            //to get the patient for the appointment ...
            bool flagPatient = false; // Flag to control the loop of getting the patient ...
            do
            {
                flagPatient = false; // Reset the flag for the loop
                newAppointment.AppointmentPatient = Patient.GetPatientByID(Validation.IntValidation("patient ID for the appointment"));
                if (newAppointment.AppointmentPatient == null)
                {
                    Console.WriteLine("Invalid patient ID. Please try again.");
                    flagPatient = true; // Set the flag to true to repeat the loop
                }
            } while (flagPatient);
            //to get the appointment date and time ...
            bool flagAppointmentDate = false; // Flag to control the loop of getting the appointment date ...
            do
            {
                flagAppointmentDate = false; // Reset the flag for the loop
                newAppointment.AppointmentDate = Validation.DateTimeValidation("appointment date and time");
                //to check if the doctor is available at the appointment date and time ...
                if (!newAppointment.AppointmentDoctor.AvailableAppointments.Contains(newAppointment.AppointmentDate))
                {
                    Console.WriteLine("The doctor is not available at the selected date and time. Please choose another date.");
                    flagAppointmentDate = true; // Set the flag to true to repeat the loop
                }
            }
            while (flagAppointmentDate);
            //to store the newAppointment to HospitalAppointments list ...
            Hospital.HospitalAppointments.Add(newAppointment);
            //to remove the appointment date from the doctor's available appointments ...
            Doctor.DeleteDoctorAvailableAppointment(newAppointment.AppointmentDoctor, newAppointment.AppointmentDate);
            Console.WriteLine("Appointment booked successfully with the following details:");
            Console.WriteLine(newAppointment.DisplayAppointment());
            Additional.HoldScreen(); // to hold the screen ...


        }
        //to GetAppointmentsList ...
        public static void GetAppointmentsList()
        {
            //to check if there are appointments in the system or not ...
            if (!GetAppointment())
            {
                return; // Exit if no appointments are available
            }
            //to display the list of appointments ...
            Console.WriteLine("List of Appointments:");
            foreach (var appointment in Hospital.HospitalAppointments)
            {
                Console.WriteLine(appointment.DisplayAppointment());
            }
        }
        //to ListAppointmentByPatientName ...
        public static void ListAppointmentByPatientName()
        {
            //to check if there are appointments in the system or not ...
            if (!GetAppointment())
            {
                return; // Exit if no appointments are available
            }
            //to get the patient name ...
            string patientName = Validation.StringNamingValidation("patient name to search for appointments");
            //to find and display appointments for the specified patient ...
            var appointments = Hospital.HospitalAppointments.Where(a => a.AppointmentPatient.PersonName.Equals(patientName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (appointments.Count == 0)
            {
                Console.WriteLine($"No appointments found for patient: {patientName}");
            }
            else
            {
                Console.WriteLine($"Appointments for patient: {patientName}");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine(appointment.DisplayAppointment());
                }
            }
        }

        //4. class Appointment constructor ...
        public Appointment()
        {
            AppointmentCount++; // Increment the static count for appointments
            AppointmentID = AppointmentCount; // Assign a unique ID to the appointment
        }
    }
}
