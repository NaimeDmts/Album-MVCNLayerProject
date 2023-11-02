using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using MVCNLayerProject.CORE.Abstraction;
using MVCNLayerProject.CORE.Enums;
using MVCNLayerProject.DAL.Contexts;
using MVCNLayerProject.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.DAL.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(T entity)
        {
            if(entity != null)
            {
                _context.Set<T>().Add(entity);
                var kontrol = _context.SaveChanges() > 0;
                if (kontrol)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Veritabanına Ekleme işlemi yansımadı Hata");
                }
            }
            else
            {
                throw new Exception("Gelen Data boş");
            }
        }

 

        public void Delete(T entity)
        {
            if( entity != null )
            {
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Silinecek data boş");
            }
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();

        }
        

        public IList<T> GetNotPassives()
        {
            return _context.Set<T>().Where(e => e.Status != Status.Passive).ToList();
        }

        public bool Update(T entity)
        {
            if(entity != null)
            {
                _context.Set<T>().Update(entity);
                var kontrol = _context.SaveChanges() > 0;
                if (kontrol)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Veritabanına yansıyan bir değişiklik olmamıştır");
                }
            }
            else
            {
                throw new Exception("Boş veri güncellenemez. Hata!");
            }
        }

        bool IBaseRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
