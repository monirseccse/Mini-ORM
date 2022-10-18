using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Address:IEntity<int,Address>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address Instantiate()
        {
            Address address = new Address { Id=1,City = "dfkl", Street = "dkf", Country = "Bd" };
            return address;
        }
    }
}
