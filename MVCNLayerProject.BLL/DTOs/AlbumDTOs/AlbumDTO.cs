using MVCNLayerProject.BLL.DTOs.SanatciDTOs;
using MVCNLayerProject.BLL.DTOs.TurDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.DTOs.AlbumDTOs
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TurId { get; set; }
        public int SanatciId { get; set; }
        public TurDTO TurDTO { get; set; }
        public SanatciDTO SanatciDTO { get; set; }
       
    }
}
