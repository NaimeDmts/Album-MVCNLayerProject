using MVCNLayerProject.BLL.DTOs.SanatciDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.SanatciServices
{
    public interface ISanatciService
    {
        public bool SanatciAdd(SanatciCreateDTO sanatciCreateDTO);
        public bool SanatciUpdate(SanatciUpdateDTO sanatciUpdateDTO);
        public void SanatciDelete(int id);
        public SanatciDTO SanatciGetById(int id);
        public IList<SanatciDTO> GetAll();
        public IList<SanatciDTO> GetNotPassiveAll();
    }
}
