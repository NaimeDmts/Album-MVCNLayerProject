using MVCNLayerProject.BLL.DTOs.AlbumDTOs;
using MVCNLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.AlbumServices
{
    public interface IAlbumService
    {
        public bool AlbumAdd(AlbumCreateDTO album);
        public bool AlbumUpdate(AlbumUpdateDTO album);
        public void AlbumDelete(int id);
        public AlbumDTO AlbumGetById(int id);
        public IList<AlbumDTO> GetAll();
        public IList<AlbumDTO> GetNotPassiveAll();
    }
}
