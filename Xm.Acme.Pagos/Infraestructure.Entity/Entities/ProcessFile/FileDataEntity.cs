using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.ProcessFile
{
    [Table("FileData", Schema = "ProcessFile")]
    public class FileDataEntity : AuditEntity
    {
        [Key]
        public int BankLoadFileDataId { get; set; }

        public string BusinessCode { get; set; }

        public string AccountNumber { get; set; }

        public string Bank { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public string Origin { get; set; }

        public int DetailQuantity { get; set; }

        public ICollection<FileDataDetailEntity> BankLoadFileDataDetail { get; set; }
    }
}
