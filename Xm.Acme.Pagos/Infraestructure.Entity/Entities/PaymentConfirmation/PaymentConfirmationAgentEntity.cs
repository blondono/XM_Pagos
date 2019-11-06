using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.PaymentConfirmation
{
    [Table("PaymentConfirmationAgent", Schema = "Payment")]
    public class PaymentConfirmationAgentEntity
    {
        [Key]
        public int PaymentConfirmationAgentId { get; set; }
        public string Agent { get; set; }
        [ForeignKey("TypeCrossingsEntity")]
        public int PaymentConfirmationId { get; set; }

        public PaymentConfirmationsEntity PaymentConfirmationsEntity { get; set; }

    }
}
