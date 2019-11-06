using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO.Configuration
{
    public class ConfigurationServiceResponseDTO<T>
    {
        public bool estado { get; set; }
        public List<T> resultado { get; set; }
        public string mensaje { get; set; }
    }
}
