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
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly AppDbContext _context;
        public AlbumRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Album AlbumGetById(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.Id == id && a.Status != Status.Passive);
        }
    }
}
