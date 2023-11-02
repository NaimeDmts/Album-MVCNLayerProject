using MVCNLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.DAL.Repositories.Abstraction
{
    public interface ISanatciRepository: IBaseRepository<Sanatci>
    {
        Sanatci SanatciGetById(int id);
    }
}
