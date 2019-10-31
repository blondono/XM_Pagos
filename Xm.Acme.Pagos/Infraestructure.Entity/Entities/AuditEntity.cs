using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities
{
    [NotMapped]
    public class AuditEntity
    {
        public DateTime? CreationDate { get; set; }

        public string CreationUser { get; set; }

        public DateTime? ModificationDate { get; set; }

        public string ModificationUser { get; set; }
    }
}
