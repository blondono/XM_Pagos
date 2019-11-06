using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.PaymentConfirmation
{
    [Table("PaymentConfirmation", Schema = "Payment")]
    public class PaymentConfirmationsEntity
    {
        [Key]
        public int PaymentConfirmationId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Company { get; set; }
        public int ConsignedValue { get; set; }
        public int PaymentReference { get; set; }
        public string Observation { get; set; }
        public int Pending { get; set; }


        public ICollection<PaymentConfirmationBusinessEntity> PaymentConfirmationBusinessEntities { get; set; }
    }
}
