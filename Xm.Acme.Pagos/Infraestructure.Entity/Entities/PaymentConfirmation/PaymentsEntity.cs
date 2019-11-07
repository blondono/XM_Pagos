using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.PaymentConfirmation
{
    [Table("Payments", Schema = "Payment")]
    public class PaymentsEntity
    {
        [Key]
        public int PaymentConfirmationAgentId { get; set; }
        public string Agent { get; set; }
        public int ConsignedValue { get; set; }
        [ForeignKey("PaymentConfirmationsEntity")]
        public int PaymentConfirmationId { get; set; }

        public PaymentConfirmationsEntity PaymentConfirmationsEntity { get; set; }

    }
}
