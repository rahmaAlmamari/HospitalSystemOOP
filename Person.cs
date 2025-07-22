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

        //2. class Person properties ...
        //3. class Person methods ... 
        //4. class Person constructor ...
        public Person(string name)
        {
            PersonCount++; // Increment the static count
            PersonID = PersonCount; // Assign the current count to the instance ID
            PersonName = name;
        }
    }
}
