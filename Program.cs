namespace HospitalSystemOOP
{
    internal class Program
    {
        //HospitalSystem Object ...
        //public static Hospital hospital = new Hospital();
        static void Main(string[] args)
        {
            //to list the main menu options ...
            bool exitFlag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add new patient");
                Console.WriteLine("2. View all room");
                Console.WriteLine("3. Reserve a room for a guest");
                Console.WriteLine("4. View all reservations with total cost");
                Console.WriteLine("5. Search reservation by guest name");
                Console.WriteLine("6. Find the highest-paying guest");
                Console.WriteLine("7. Cancel a reservation by room number");
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
                    case '0':
                        exitFlag = true;
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
