using MVCNLayerProject.BLL.DTOs.AlbumDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.DTOs.TurDTOs
{
    public class TurDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AlbumDTO> Albums { get; set; }
    }
}
