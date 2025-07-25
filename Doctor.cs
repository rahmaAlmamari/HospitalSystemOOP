﻿using System;
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
        //to hold doctor data to file ...
        public static string DoctorDataFile = "doctors.txt"; // File to store doctor data
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
            // to display the doctor information ...
            Console.WriteLine(newDoctor.DisplayInfo());
            //to display the available appointments for the doctor ...
            newDoctor.DisplayDoctorAvailableAppointments(newDoctor);
            Additional.HoldScreen();//to hold the screen ...
        }
        //to DisplayDoctorAvailableAppointments ...
        public void DisplayDoctorAvailableAppointments(Doctor doctor)
        {
            //to check if there are available appointments for the doctor or not ...
            if (doctor.AvailableAppointments.Count == 0)
            {
                Console.WriteLine("No available appointments for this doctor.");
                return;
            }
            //to display the available appointments for the doctor ...
            Console.WriteLine($"Available appointments for Dr. {doctor.PersonName}:");
            for(int i = 0; i < doctor.AvailableAppointments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableAppointments[i].ToString("dd/MM/yyyy HH:mm")}");
            }
        }
        //to GetDoctorList ...
        public static void GetDoctorList()
        {
            //to check if there are doctors in the system or not ...
            if (!GetDoctor())
            {
                return; // Exit if no doctors are available
            }
            //to display the list of doctors ...
            Console.WriteLine("List of Doctors:");
            foreach (var doctor in Hospital.HospitalDoctors)
            {
                // Display doctor information ...
                Console.WriteLine(doctor.DisplayInfo());
                // Display available appointments for each doctor ...
                doctor.DisplayDoctorAvailableAppointments(doctor);
                Console.WriteLine("-------------------------------------------\n");

            }
        }
        //to GetDoctorByID ...
        public static Doctor GetDoctorByID(int doctorID)
        {
            //to check if there are doctors in the system or not ...
            if (!GetDoctor())
            {
                return null; // Exit if no doctors are available
            }
            //to find the doctor by ID ...
            Doctor doctor = Hospital.HospitalDoctors.FirstOrDefault(d => d.PersonID == doctorID);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found with the given ID.");
                return null; // Return null if no doctor is found
            }
            return doctor; // Return the found doctor
        }
        //to delete a doctor available appointment ...
        public static void DeleteDoctorAvailableAppointment(Doctor doctor, DateTime appointment)
        {
            if (doctor.AvailableAppointments.Contains(appointment))
            {
                doctor.AvailableAppointments.Remove(appointment);
                Console.WriteLine($"Appointment on {appointment.ToString("dd/MM/yyyy HH:mm")} has been removed.");
                Additional.HoldScreen(); // Hold the screen after deletion
            }
            else
            {
                Console.WriteLine("Appointment not found in the doctor's available appointments.");
                Additional.HoldScreen(); // Hold the screen if appointment not found
            }
        }
        //to search a doctor by specialization ...
        public static void SearchDoctorBySpecialization()
        {
            //to check if there are doctors in the system or not ...
            if (!GetDoctor())
            {
                return; // Exit if no doctors are available
            }
            //to get the specialization from the user ...
            string specialization = Validation.StringValidation("doctor specialization");
            //to find the doctors by specialization ...
            var doctors = Hospital.HospitalDoctors.Where(d => d.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase)).ToList();
            //.Equals(specialization, StringComparison.OrdinalIgnoreCase) ==>
            //checks if the doctor’s specialization matches the specialization variable, ignoring case sensitivity
            if (doctors.Count == 0)
            {
                Console.WriteLine($"No doctors found with specialization: {specialization}");
                Additional.HoldScreen(); // Hold the screen if no doctors found
                return;
            }
            //to display the found doctors ...
            Console.WriteLine($"Doctors with specialization '{specialization}':");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.DisplayInfo());
                Console.WriteLine("-------------------------------------------\n");
            }
            Additional.HoldScreen(); // Hold the screen after displaying doctors
        }
        //to save the doctors to a file ...
        public static void SaveDoctorsToFile()
        {
            //to check if there are doctors in the system or not ...
            if (!GetDoctor())
            {
                return; // Exit if no doctors are available
            }
            //to save the doctors to a file ...
            using (StreamWriter writer = new StreamWriter("doctors.txt"))
            {
                foreach (var doctor in Hospital.HospitalDoctors)
                {
                    writer.WriteLine(doctor.DisplayInfo());
                    // Write available appointments to the file ...
                    writer.WriteLine("Available Appointment:");
                    foreach (var appointment in doctor.AvailableAppointments)
                    {
                        writer.WriteLine($"{appointment.ToString("dd/MM/yyyy HH:mm")}");
                    }
                    writer.WriteLine("=========================================================");
                }
            }
            Console.WriteLine("Doctors saved to file successfully.");
            Additional.HoldScreen(); // Hold the screen after saving
        }
        //to load the doctors data from file ...
        public static void LoadDoctorsDetailsFromFile()
        {
            try
            {
                if (!File.Exists(Doctor.DoctorDataFile))
                {
                    Console.WriteLine("No saved doctor details found.");
                    Additional.HoldScreen();
                    return;
                }

                Hospital.HospitalDoctors.Clear(); // Clear old data

                using (StreamReader reader = new StreamReader(Doctor.DoctorDataFile))
                {
                    string line;
                    Doctor doctor = null;
                    bool readingAppointments = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Doctor ID:"))
                        {
                            int id = int.Parse(line.Split(':')[1].Trim());

                            string nameLine = reader.ReadLine();
                            string ageLine = reader.ReadLine();
                            string specLine = reader.ReadLine();
                            string separator = reader.ReadLine(); // Skip dashed line

                            string name = nameLine.Split(':')[1].Trim();
                            int age = int.Parse(ageLine.Split(':')[1].Trim());
                            string specialization = specLine.Split(':')[1].Trim();

                            doctor = new Doctor(name, age);
                            doctor.PersonID = id;
                            doctor.Specialization = specialization;
                            doctor.AvailableAppointments = new List<DateTime>();
                        }
                        else if (line.StartsWith("Available Appointment:"))
                        {
                            readingAppointments = true;
                        }
                        else if (line.StartsWith("==="))
                        {
                            // End of doctor record
                            if (doctor != null)
                            {
                                Hospital.HospitalDoctors.Add(doctor);
                                doctor = null;
                            }
                            readingAppointments = false;
                        }
                        else if (readingAppointments && doctor != null)
                        {
                            if (DateTime.TryParseExact(line, "dd/MM/yyyy HH:mm", null,
                                System.Globalization.DateTimeStyles.None, out DateTime appointment))
                            {
                                doctor.AvailableAppointments.Add(appointment);
                            }
                        }
                    }
                }

                Console.WriteLine("Doctors loaded from file successfully.");
                Additional.HoldScreen();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading doctors: " + ex.Message);
                Additional.HoldScreen();
            }
        }

        //4. class Doctor constructor ...
        public Doctor(string name, int personAge) : base(name, personAge)
        {
            DoctorCount++; // Increment the static count for doctors
            // Doctor specific initialization can go here if needed
        }
    }
}
