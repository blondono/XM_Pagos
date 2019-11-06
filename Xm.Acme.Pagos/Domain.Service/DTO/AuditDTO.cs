using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO
{
    public class AuditDTO
    {
        public DateTime? CreationDate { get; set; }

        public string CreationUser { get; set; }

        public DateTime? ModificationDate { get; set; }

        public string ModificationUser { get; set; }
    }
}
