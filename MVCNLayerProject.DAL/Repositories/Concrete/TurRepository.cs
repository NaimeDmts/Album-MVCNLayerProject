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
    public class TurRepository : BaseRepository<Tur>, ITurRepository
    {
        private readonly AppDbContext _context;
        public TurRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Tur TurGetById(int id)
        {
            return _context.Turs.FirstOrDefault(a => a.Id == id && a.Status != Status.Passive);
        }
    }
}
