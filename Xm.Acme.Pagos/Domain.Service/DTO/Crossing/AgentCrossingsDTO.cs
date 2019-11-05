using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO.Crossing
{
    public class AgentCrossingsDTO
    {
        public int AgentCrossingId { get; set; }
        public string Business { get; set; }
        public string Agent { get; set; }
        public int TypeCrossingId { get; set; }
        public string TypeCrossing { get; set; }
        public DateTime InitialValidity { get; set; }
        public DateTime? FinalValidity { get; set; }
        public string Company { get; set; }
        public int Value { get; set; }
        public DateTime DueDate { get; set; }
        public bool? Crossed { get; set; }
        public bool? FullPaymentDebts { get; set; }
    }
}
