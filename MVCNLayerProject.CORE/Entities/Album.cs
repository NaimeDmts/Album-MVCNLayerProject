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
    [Table("TblAlbum")]
    public class Album :IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public int SanatciId { get; set; }
        public int TurId { get; set; }
        //Navigaztion Properties
        public virtual Sanatci Sanatci { get; set; }    
        public virtual Tur Tur { get; set; }
    }
}
