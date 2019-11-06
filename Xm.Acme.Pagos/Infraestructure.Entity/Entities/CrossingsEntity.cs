using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities
{
    [Table("Crossings", Schema = "Crossing")]
    public class CrossingsEntity : AuditEntity
    {
        [Key]
        public int CrossingId { get; set; }
        public string Business { get; set; }
        [ForeignKey("TypeCrossingsEntity")]
        public int TypeCrossingId { get; set; }
        public DateTime InitialValidity { get; set; }
        public DateTime? FinalValidity { get; set; }
        public string Company { get; set; }
        public int Value { get; set; }
        public DateTime DueDate { get; set; }
        public bool? Crossed { get; set; }
        public bool? FullPaymentDebts { get; set; }
        public bool Enabled { get; set; }

        public TypeCrossingsEntity TypeCrossingsEntity { get; set; }
        public ICollection<AgentCrossingsEntity> AgentCrossingsEntities { get; set; }
    }
}
