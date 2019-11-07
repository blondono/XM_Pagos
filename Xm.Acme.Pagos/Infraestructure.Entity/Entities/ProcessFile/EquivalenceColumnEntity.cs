using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Entities.ProcessFile
{
    [Table("EquivalenceColumn", Schema = "ProcessFile")]
    public class EquivalenceColumnEntity : AuditEntity
    {
        [Key]
        public string Origin { get; set; }

        public string Bank { get; set; }

        public string Type { get; set; }

        public string EquivalenceColumn { get; set; }

        public int Position { get; set; }

        public string ColumnName { get; set; }
    }
}
