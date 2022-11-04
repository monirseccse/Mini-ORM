using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Course : IEntity<int,Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Fees { get; set; }
        public Instructor Teacher { get; set; }
        public List<Topic> Topics { get; set; }
        public List<AdmissionTest> AdmissionTests { get; set; }

        public Course Instantiate()
        {
            Course course = new Course
            {   Id=1,
                Title = "Asp.net",
                Fees = 30000,
                Teacher = new Instructor
                {
                    Id = 1,
                    Name = "gfh",
                    Email = "hj",
                    PresentAddress =
                  new Address { Id = 1, City = "jk", Country = "jhj", Street = "ui" },
                    PermanentAddress = new Address {Id=1, City = "jk", Country = "jhj", Street = "ui" },
                    PhoneNumbers = new List<Phone>
                    {
                     new Phone {Id=1, CountryCode="hj",Extension="gh",Number="67"},
                     new Phone{ Id=2, CountryCode="abc",Extension="iop",Number="4567"} 
                    }
                },
                Topics = new List<Topic>
                {
                   new Topic
                   {Id=1,
                        Description = "Thread Safety",
                    Title = "Thread",
                    Sessions = new List<Session>
                    {
                    new Session{Id=1,DurationInHour=5,LearningObject="abc"},
                    new Session{Id=2,DurationInHour=2,LearningObject="df"}
                     }
                   }
                },
                AdmissionTests = new List<AdmissionTest>
                {
                  new AdmissionTest
                  {Id=1,
                      StartTime =DateTime.Now,
                EndTime =DateTime.Now.AddHours(3),
                Fees =500
                  },
                   new AdmissionTest
                  {Id = 2,
                      StartTime =DateTime.Now.AddDays(1),
                EndTime =DateTime.Now.AddDays(1).AddHours(2),
                Fees =500
                  }
     }
            };
            return course;
        }
    }
}
