using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KredekTests_Template.Database
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }
    }
}
