using MVCNLayerProject.BLL.DTOs.AlbumDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.DTOs.SanatciDTOs
{
    public class SanatciDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AlbumDTO> Albums { get; set; }
    }
}
