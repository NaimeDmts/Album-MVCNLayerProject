using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.CORE.Enums;
using MVCNLayerProject.DAL.Contexts;
using MVCNLayerProject.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.DAL.Repositories.Concrete
{
    public class SanatciRepository : BaseRepository<Sanatci>, ISanatciRepository
    {
        private readonly AppDbContext _contex;
        public SanatciRepository(AppDbContext context) : base(context)
        {
            _contex = context;
        }

        public Sanatci SanatciGetById(int id)
        {
            return _contex.Sanatcis.FirstOrDefault(a => a.Status != Status.Passive && a.Id == id);
        }
    }
}
