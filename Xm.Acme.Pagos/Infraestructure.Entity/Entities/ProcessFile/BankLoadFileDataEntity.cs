using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.ProcessFile
{
    [Table("BankFileAdmin", Schema = "ProcessFile")]
    public class BankLoadFileDataEntity
    {
        [Key]
        public int BankLoadFileDataId { get; set; }

        public string BusinessCode { get; set; }

        public string Bank { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public string Origin { get; set; }

        public ICollection<BankLoadFileDataDetailEntity> BankLoadFileDataDetail { get; set; }
    }
}
