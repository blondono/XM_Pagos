using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities
{
    [Table("AgentCrossings", Schema = "Crossing")]
    public class AgentCrossingsEntity : AuditEntity
    {
        [Key]
        public int AgentCrossingId { get; set; }
        public string Business { get; set; }
        public string Agent { get; set; }
        [ForeignKey("TypeCrossingsEntity")]
        public int TypeCrossingId { get; set; }
        public DateTime InitialValidity { get; set; }
        public DateTime FinalValidity { get; set; }
        public string Company { get; set; }
        public int Value { get; set; }
        public DateTime DueDate { get; set; }
        public bool? Crossed { get; set; }

        public TypeCrossingsEntity TypeCrossingsEntity { get; set; }
    }
}
