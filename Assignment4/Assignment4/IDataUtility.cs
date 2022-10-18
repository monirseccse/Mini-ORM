using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public interface IDataUtility
    {
       void ExecuteCommand(string command,Dictionary<string,object> parameters);
    }
}
