using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO.Crossing
{
    public class AgentCrossingsResponseDTO
    {
        public int AgentCrossingId { get; set; }
        public string Business { get; set; }
        public string Agent { get; set; }
        public int TypeCrossingId { get; set; }
        public string TypeCrossing { get; set; }
        public string InitialValidity { get; set; }
        public string FinalValidity { get; set; }
        public string Company { get; set; }
        public string DueDate { get; set; }
        public bool? Crossed { get; set; }
    }
}
