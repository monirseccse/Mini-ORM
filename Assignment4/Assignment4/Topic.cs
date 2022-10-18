using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Topic : IEntity<int,Topic>
    {
        public int Id{ get; set; }
        public string Title { get; set; }

        public List<Session> Sessions { get; set; }
        public string Description { get; set; }
        
       public Topic Instantiate()
        {
            Topic topic = new Topic
            {
                Id = 2,
                Description = "Delgate & events",
                Title = "Delegate",
                Sessions = new List<Session>
               {
                new Session{ Id=3,DurationInHour=1,LearningObject="List"},
                new Session{Id=4,DurationInHour=2,LearningObject="Dictionary"}
               }
            };
            return topic;
        }
       
    }
}
