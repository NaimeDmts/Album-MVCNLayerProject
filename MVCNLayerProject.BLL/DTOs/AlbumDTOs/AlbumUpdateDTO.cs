using MVCNLayerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.DTOs.AlbumDTOs
{
    public class AlbumUpdateDTO
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int TurId { get; set; }
        public int SanatciId { get; set; }

    }
}
