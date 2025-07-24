namespace HospitalSystemOOP
{
    internal class Program
    {
        //HospitalSystem Object ...
        //public static Hospital hospital = new Hospital();
        static void Main(string[] args)
        {
            //to display the welcome message ...
            Additional.WelcomeMessage("Hospital Management");
            //to load doctors data from file if exist ...
            Doctor.LoadDoctorsDetailsFromFile();
            //to list the main menu options ...
            bool exitFlag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add new patient");
                Console.WriteLine("2. Add new doctor");
                Console.WriteLine("3. Booking an appointment");
                Console.WriteLine("4. Displaying all appointments");
                Console.WriteLine("5. Showing available doctors by specialization");
                Console.WriteLine("6. Search for appointments by patient name");
                Console.WriteLine("7. Search for appointments by date");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");

                //to get the user choice ...
                char choice = Validation.CharValidation("option");
                switch (choice)
                {
                    case '1':
                        //to add a new patient ...
                        Patient.AddPatient();
                        break;
                    case '2':
                        //to add a new doctor ...
                        Doctor.AddDoctors();
                        break;
                    case '3':
                        //to Booking an appointment ...
                        Appointment.BookAppointment();
                        break;
                    case '4':
                        //to displaying all appointments ...
                        Appointment.GetAppointmentsList();
                        break;
                    case '5':
                        //to showing available doctors by specialization ...
                        Doctor.SearchDoctorBySpecialization();
                        break;
                    case '6':
                        //to search for appointments by patient name ...
                        Appointment.ListAppointmentByPatientName();
                        break;
                    case '7':
                        //to search for appointments by date ...
                        Appointment.ListAppointmentByDate();
                        break;
                    case '0':
                        exitFlag = true;
                        //to save doctors data to file ...
                        Doctor.SaveDoctorsToFile();
                        Console.WriteLine("Thank you for using the Hotel System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        Additional.HoldScreen();
                        break;
                }
            } while (!exitFlag);
        }
    }
}
