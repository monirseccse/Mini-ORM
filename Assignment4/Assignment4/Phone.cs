using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Phone : IEntity<int,Phone>
    {
       public int Id { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public string CountryCode { get; set; }

        public Phone Instantiate()
        {
            Phone phone1 = new Phone { CountryCode = "hj", Extension = "gh", Number = "67" };
           return phone1;
         }
    }
}
