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
                Title = "C#",
                Fees = 5000,
                Teacher = new Instructor
                {
                    Id = 1,
                    Name = "gfh",
                    Email = "hj",
                    PresentAddress =
                  new Address { Id = 1, City = "jk", Country = "jhj", Street = "ui" },
                    PermanentAddress = new Address { City = "jk", Country = "jhj", Street = "ui" },
                    PhoneNumbers = new List<Phone> {new Phone { CountryCode="hj",Extension="gh",Number="67"},
                  new Phone{  CountryCode="abc",Extension="iop",Number="4567"} }
                },
                Topics = new List<Topic>
                {
                   new Topic
                   {
                        Description = "Thread Safety",
                    Title = "Thread",
                    Sessions = new List<Session>
                    {
                    new Session{DurationInHour=5,LearningObject="abc"},
                    new Session{DurationInHour=2,LearningObject="df"}
                     }
                   },
                    new Topic
                   {
                        Description = "Async",
                    Title = "Pro",
                    Sessions = new List<Session>
                    {
                    new Session{DurationInHour=7,LearningObject="xyz"},
                    new Session{DurationInHour=88,LearningObject="lkj"}
                     }
                   }
                },
                AdmissionTests = new List<AdmissionTest>
                {
                  new AdmissionTest
                  {
                      StartTime =DateTime.Now,
                EndTime =DateTime.Now.AddHours(3),
                Fees =500
                  },
                   new AdmissionTest
                  {
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
