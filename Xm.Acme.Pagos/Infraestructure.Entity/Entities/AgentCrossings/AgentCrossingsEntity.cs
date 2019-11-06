using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.AgentCrossings
{
    [Table("AgentCrossings", Schema = "Crossing")]
    public class AgentCrossingsEntity : AuditEntity
    {
        [Key]
        public int AgentCrossingId { get; set; }
        [ForeignKey("CrossingsEntity")]
        public int CrossingId { get; set; }
        public string Agent { get; set; }
        public CrossingsEntity CrossingsEntity { get; set; }
    }
}
