using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Session : IEntity<int, Session>
    {
        public int Id { get; set; }
        public int DurationInHour { get; set; }
        public string LearningObject { get; set; }
        
        public Session Instantiate()
        {
            Session session1= new Session { Id = 1, DurationInHour = 5, LearningObject = "abc" };
            return session1 ;
        }
    }
}
