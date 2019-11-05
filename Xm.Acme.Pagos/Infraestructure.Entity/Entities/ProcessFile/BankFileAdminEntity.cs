using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.ProcessFile
{
    [Table("BankFileAdmin", Schema = "ProcessFile")]
    public class BankFileAdminEntity
    {
        [Key]
        public int BankFileAdminId { get; set; }

        public string BusinessCode { get; set; }

        public string BankCode { get; set; }

        public string HeadFileName { get; set; }

        public string DetailFileName { get; set; }

        public string ReadFolder { get; set; }

        public bool Status { get; set; }
    }
}
