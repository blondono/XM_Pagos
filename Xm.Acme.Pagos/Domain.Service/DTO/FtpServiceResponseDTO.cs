using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO
{
    public class FtpServiceResponseDTO
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Error { get; set; }
        public object Data { get; set; }
    }
}
