using MVCNLayerProject.BLL.DTOs.TurDTOs;
using MVCNLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.TurServices
{
    public interface ITurService
    {
        public bool TurAdd(TurCreateDTO tur);
        public bool TurUpdate(TurUpdateDTO tur);
        public void TurDelete(int id);
        public TurDTO TurGetById(int id);
        public IList<TurDTO> GetAll();
        public IList<TurDTO> GetNotPassiveAll();
    }
}
