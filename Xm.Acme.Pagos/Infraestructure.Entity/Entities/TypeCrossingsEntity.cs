using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities
{
    [Table("TypeCrossings", Schema = "Crossing")]
    public class TypeCrossingsEntity : AuditEntity
    {
        [Key]
        public int TypeCrossingId { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }

        public ICollection<CrossingsEntity> CrossingsEntities { get; set; }
    }
}
