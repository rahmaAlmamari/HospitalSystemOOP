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
        //2. class Patient properties ...
        //3. class Patient methods ...
        //4. class Patient constructor ...
        public Patient(string name, int personAge) : base(name, personAge)
        {
            // Patient specific initialization can go here if needed
        }
    }
}
