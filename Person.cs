﻿using System;
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
        public int P_Age
        {
            get { return PersonAge; }
            set
            {
                bool FalgError = false; //to handle the error ...
                do
                {
                    FalgError = false; //to reset the error flag ...
                    if (value < 0)
                    {
                        Console.WriteLine("Age cannot be negative.");
                        FalgError = true; //to handle the error ...
                        value = Validation.IntValidation("person age"); //to get the person age again ...
                    }
                    PersonAge = value;
                } while (FalgError);

            }
        }

        //3. class Person methods ... 
        //to display person information ...
        public virtual string DisplayInfo()
        {
            return ($"ID: {PersonID}, Name: {PersonName}, Age: {P_Age}");
        }
        //4. class Person constructor ...
        public Person(string name , int personAge)
        {
            PersonCount++; // Increment the static count
            PersonID = PersonCount; // Assign the current count to the instance ID
            PersonName = name;
            P_Age = personAge;
        }
    }
}
