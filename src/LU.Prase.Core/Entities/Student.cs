using LU.Prase.Authorization.Users;
using LU.Prase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Entities
{
    public class Student : User
    {

        public string Supervisor {  get; set; }
        
        public string Major { get; set; }

        public EducationalLevel EducationalLevel { get; set; }

        public string University { get; set; }

        public string Faculty { get; set; }

    }
}
