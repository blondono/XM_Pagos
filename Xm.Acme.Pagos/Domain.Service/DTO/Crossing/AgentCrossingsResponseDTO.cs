using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO.Crossing
{
    public class AgentCrossingsResponseDTO
    {
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
    }
}
