using AutoMapper;
using MVCNLayerProject.BLL.DTOs.AlbumDTOs;
using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.CORE.Enums;
using MVCNLayerProject.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.AlbumServices
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repo;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public bool AlbumAdd(AlbumCreateDTO albumDTO)
        {
            if (albumDTO == null)
            {
                throw new Exception("Service Katmanına eklenmek için Boş veri geldi");
            }
            Album album = _mapper.Map<Album>(albumDTO);
            return _repo.Add(album);
        }

        public void AlbumDelete(int id)
        {
            Album album = _repo.AlbumGetById(id);
            if(album!=null)
            {
               album.Status =Status.Passive;
               album.DeleteDate = DateTime.Now;
               _repo.Delete(album);
            }
            else
            {
                throw new Exception("Id'ye ait Album bulunmamaktadır.");
            }
        }

        public AlbumDTO AlbumGetById(int id)
        {
            Album album = _repo.AlbumGetById(id);
            if (album != null)
            {
                AlbumDTO albumDTO = _mapper.Map<AlbumDTO>(album);
                return albumDTO;
            }
            else
            {
                throw new Exception("Id'ye Ait Album Bulunamamıştır.");
            }
        }

        public bool AlbumUpdate(AlbumUpdateDTO albumUpdateDTO)
        {
            Album album = _mapper.Map<Album>(albumUpdateDTO);
            album.Status = Status.Modified;
            album.UpdateDate = DateTime.Now;
            return _repo.Update(album);
        }

        public IList<AlbumDTO> GetAll()
        {
            IList<Album> albumList = _repo.GetAll();
            IList<AlbumDTO> albumDTOs = _mapper.Map<IList<Album>, IList<AlbumDTO>>(albumList);
            return albumDTOs;
        }

        public IList<AlbumDTO> GetNotPassiveAll()
        {
            IList<Album> albums = _repo.GetNotPassives();
            IList<AlbumDTO> albumDTOs = _mapper.Map<IList<Album>, IList<AlbumDTO>>(albums);
            return albumDTOs;
        }
    }
}
