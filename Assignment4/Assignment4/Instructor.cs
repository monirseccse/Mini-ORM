using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Instructor : IEntity<int,Instructor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address PresentAddress { get; set; }
        public Address PermanentAddress { get; set; }
        public List<Phone>PhoneNumbers { get; set; }

        public Instructor Instantiate()
        {
            Instructor instructor = new Instructor
            {
                Id = 1,
                Name = "gfh",
                Email = "hj",
                PresentAddress =
        new Address { Id = 1, City = "jk", Country = "jhj", Street = "ui" },
                //  PermanentAddress=new Address{ City = "jk", Country = "jhj", Street = "ui" },
                PhoneNumbers = new List<Phone> {new Phone {Id =1, CountryCode="hj",Extension="gh",Number="67"},
          new Phone{ Id =2, CountryCode="abc",Extension="iop",Number="4567"} }
            };
            return instructor;
        }

    }
}
