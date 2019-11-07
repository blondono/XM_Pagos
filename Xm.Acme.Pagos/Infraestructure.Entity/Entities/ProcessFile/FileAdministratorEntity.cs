using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.ProcessFile
{
    [Table("FileAdministrator", Schema = "ProcessFile")]
    public class FileAdministratorEntity : AuditEntity
    {
        [Key]
        public int BankFileAdminId { get; set; }

        public string BusinessCode { get; set; }

        public string BankCode { get; set; }

        public string HeadFileName { get; set; }

        public string DetailFileName { get; set; }

        public string ReadFolder { get; set; }

        public int StartLine { get; set; }

        public bool Status { get; set; }
    }
}
