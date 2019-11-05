using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Services.Interface
{
    public interface IFtpFileService
    {
        byte[] GetFileMulticash(string path, string fileName); 
    }
}
