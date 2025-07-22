using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemOOP
{
    class Person
    {
        //1. class Person feilds ...
        public static int PersonCount = 0;
        public int PersonID;
        public string PersonName;
        public int PersonAge;

        //2. class Person properties ...
        //3. class Person methods ... 
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {PersonID}, Name: {PersonName}, Age: {PersonAge}");
        }
        //4. class Person constructor ...
        public Person(string name , int personAge)
        {
            PersonCount++; // Increment the static count
            PersonID = PersonCount; // Assign the current count to the instance ID
            PersonName = name;
            PersonAge = personAge;
        }
    }
}
