using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO.Crossing
{
    public class AgentCrossingsFilterDTO
    {
        public string Business { get; set; }
        public string Agent { get; set; }
        public int TypeCrossingId { get; set; }
        public string DueDate { get; set; }
    }
}
