using MVCNLayerProject.CORE.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.DAL.Repositories.Abstraction
{
    public interface IBaseRepository<T> where T : class, IBaseEntity 
    {
        bool Add (T entity);
        bool Update (T entity);
        bool Delete (T entity);
        IList<T> GetAll ();
        IList<T> GetNotPassives ();
      
    }
}
