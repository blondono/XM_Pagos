using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.PaymentConfirmation
{
    [Table("PaymentsConfirmation", Schema = "Payment")]
    public class PaymentConfirmationsEntity
    {
        [Key]
        public int PaymentConfirmationId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Company { get; set; }
        public int TotalConsigned { get; set; }
        public string Observation { get; set; }
        public int Pending { get; set; }


        public ICollection<PaymentsEntity> PaymentsEntities { get; set; }
    }
}
