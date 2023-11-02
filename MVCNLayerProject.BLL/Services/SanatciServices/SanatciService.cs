using AutoMapper;
using MVCNLayerProject.BLL.DTOs.SanatciDTOs;
using MVCNLayerProject.BLL.DTOs.TurDTOs;
using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.CORE.Enums;
using MVCNLayerProject.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.SanatciServices
{
    public class SanatciService : ISanatciService
    {
        private readonly ISanatciRepository _repo;
        private readonly IMapper _mapper;

        public SanatciService(ISanatciRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IList<SanatciDTO> GetAll()
        {
            IList<Sanatci> sanatcis = _repo.GetAll();
            IList<SanatciDTO> sanatciDTOs = _mapper.Map<IList<Sanatci>, IList<SanatciDTO>>(sanatcis);
            return sanatciDTOs;

        }

        public IList<SanatciDTO> GetNotPassiveAll()
        {
            IList<Sanatci> sanatcis = _repo.GetNotPassives();
            IList<SanatciDTO> sanatciDTOs = _mapper.Map<IList<Sanatci>, IList<SanatciDTO>>(sanatcis);
            return sanatciDTOs;
        }

        public bool SanatciAdd(SanatciCreateDTO sanatciCreateDTO)
        {
            if (sanatciCreateDTO != null)
            {
                Sanatci sanatci = _mapper.Map<Sanatci>(sanatciCreateDTO);
                return _repo.Add(sanatci);
            }
            else
            {
                throw new Exception("Eklemek için boş veri gönderildi");
            }
        }

        public void SanatciDelete(int id)
        {
            Sanatci sanatci = _repo.SanatciGetById(id);
            if (sanatci != null)
            {
                sanatci.Status = Status.Passive;
                sanatci.DeleteDate = DateTime.Now;
                _repo.Delete(sanatci);
            }
            else
            {
                throw new Exception("Silinmek istenen Id bulunmamaktadır.");
            }
        }

        public SanatciDTO SanatciGetById(int id)
        {
            Sanatci sanatci = _repo.SanatciGetById(id);
            if (sanatci != null)
            {
                SanatciDTO sanatciDTO = _mapper.Map<SanatciDTO>(sanatci);
                return sanatciDTO; 
            }
            else
            {
                throw new Exception("Id ye ait veri bulunamamıştır");
            }
        }

        public bool SanatciUpdate(SanatciUpdateDTO sanatciUpdateDTO)
        {
            if (sanatciUpdateDTO != null)
            {
                Sanatci sanatci = _mapper.Map<Sanatci>(sanatciUpdateDTO);
                sanatci.Status = Status.Modified;
                sanatci.UpdateDate = DateTime.Now;
                return _repo.Update(sanatci);
            }
            else
            {
                throw new Exception("Silinmek istenen Id bulunmamaktadır.");
            }
        }
    }
}
