using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public interface IMyORM<TKey, TEntity> where TEntity : class, IEntity<TKey, TEntity>
    {
       void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey key);
        void GetById(TKey id);
        void GetAll();
    }
}
