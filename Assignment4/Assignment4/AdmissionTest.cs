using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class AdmissionTest:IEntity<int,AdmissionTest>
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Fees { get; set; }
        
        public AdmissionTest Instantiate()
        {
            AdmissionTest admissionTest = new AdmissionTest { Id=1,StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(3), Fees = 500 };
            return admissionTest;
        }
    }
}
