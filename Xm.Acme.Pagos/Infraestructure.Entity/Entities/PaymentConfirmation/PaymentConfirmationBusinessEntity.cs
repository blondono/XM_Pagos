using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.PaymentConfirmation
{
    [Table("PaymentConfirmationBusiness", Schema = "Payment")]
    public class PaymentConfirmationBusinessEntity
    {
        [Key]
        public int PaymentConfirmationBusinessId { get; set; }
        public string Business { get; set; }
        [ForeignKey("TypeCrossingsEntity")]
        public int PaymentConfirmationId { get; set; }

        public PaymentConfirmationsEntity PaymentConfirmationsEntity { get; set; }

    }
}
