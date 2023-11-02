using MVCNLayerProject.CORE.Abstraction;
using MVCNLayerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.CORE.Entities
{
    [Table("TblSanatci")]
    public class Sanatci : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        //Navigation Properties
        public virtual ICollection<Album> Albums { get; set; }
    }
}
