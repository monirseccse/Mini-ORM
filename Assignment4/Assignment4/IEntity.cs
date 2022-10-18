using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public interface IEntity<Tkey,TEntity> where TEntity : class
    {
        public Tkey Id { get; set; }
        TEntity Instantiate();
        

    }
}
