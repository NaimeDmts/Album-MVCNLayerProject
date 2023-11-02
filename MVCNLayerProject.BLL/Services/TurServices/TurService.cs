using AutoMapper;
using MVCNLayerProject.BLL.DTOs.TurDTOs;
using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.CORE.Enums;
using MVCNLayerProject.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.TurServices
{
    public class TurService : ITurService
    {
        private readonly ITurRepository _repo;
        private readonly IMapper _mapper;

        public TurService(ITurRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IList<TurDTO> GetAll()
        {
            IList<Tur> turs = _repo.GetAll();
            IList<TurDTO> turDTOs = _mapper.Map<IList<Tur>, IList<TurDTO>>(turs);
            return turDTOs;
        }

        public IList<TurDTO> GetNotPassiveAll()
        {
            IList<Tur> turs = _repo.GetNotPassives();
            IList<TurDTO> turDTOs = _mapper.Map<IList<Tur>, IList<TurDTO>>(turs);
            return turDTOs;
        }

        public bool TurAdd(TurCreateDTO turDTO)
        {
            if(turDTO != null)
            {
                Tur tur = _mapper.Map<Tur>(turDTO);
                return _repo.Add(tur);
            }
            else
            {
                throw new Exception("Eklemek için boş veri gönderildi");
            }
           
        }

        public void TurDelete(int id)
        {
            Tur tur = _repo.TurGetById(id);
            if(tur != null)
            {
                tur.Status =  Status.Passive;
                tur.DeleteDate = DateTime.Now;
                _repo.Delete(tur);
            }
            else
            {
                throw new Exception("Silinmek istenen Id bulunmamaktadır.");
            }
        }

        public TurDTO TurGetById(int id)
        {
            Tur tur = _repo.TurGetById(id);
            if(tur != null)
            {
                TurDTO turDTO = _mapper.Map<TurDTO>(tur);
                return turDTO;
            }
            else
            {
                throw new Exception("Id ye ait veri bulunamamıştır");
            }
        }

        public bool TurUpdate(TurUpdateDTO turUpdateDTO)
        {
            if (turUpdateDTO != null)
            {
                Tur tur = _mapper.Map<Tur>(turUpdateDTO);
                tur.Status = Status.Modified;
                tur.UpdateDate = DateTime.Now;
                return _repo.Update(tur);
            }
            else
            {
                throw new Exception("Güncellenmek istene data boş");
            }
        }
    }
}
