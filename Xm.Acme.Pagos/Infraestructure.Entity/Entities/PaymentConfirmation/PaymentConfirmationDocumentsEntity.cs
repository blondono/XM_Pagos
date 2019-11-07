using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.PaymentConfirmation
{
    [Table("PaymentConfirmationDocuments", Schema = "Payment")]
    public class PaymentConfirmationDocumentsEntity
    {
        [Key]
        public int PaymentConfirmationDocumentId { get; set; }
        public byte[] Document { get; set; }
        [ForeignKey("TypeCrossingsEntity")]
        public int PaymentConfirmationId { get; set; }

        public PaymentConfirmationsEntity PaymentConfirmationsEntity { get; set; }

    }
}
