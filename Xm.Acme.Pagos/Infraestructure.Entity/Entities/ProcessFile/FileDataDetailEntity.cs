using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.ProcessFile
{
    [Table("FileDataDetail", Schema = "ProcessFile")]
    public class FileDataDetailEntity
    {
        [Key]
        public int BankLoadFileDataDetailId { get; set; }

        public string TransactionDate { get; set; }

        public string TransactionName { get; set; }

        public int DebitValue { get; set; }

        public int CreditValue { get; set; }

        public int Balance { get; set; }

        [ForeignKey("BankLoadFileDataEntity")]
        public int BankLoadFileDataId { get; set; }

        public FileDataEntity BankLoadFileDataEntity { get; set; }
    }
}
