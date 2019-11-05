using Domain.Service.DTO;
using Domain.Service.Services.Interface;
using Infraestructure.Core.RestServices.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Services
{
    public class FtpFileService : IFtpFileService
    {
        #region Atributes

        public readonly IConfiguration configuration;
        public readonly IRestService restService;

        #endregion

        #region Constructor

        public FtpFileService(IRestService pRestService)
        {
            this.restService = pRestService;
        }

        #endregion

        #region Methods

        public byte[] GetFileMulticash(string path, string fileName)
        {
            byte[] result = null;

            IConfiguration conf = configuration.GetSection("FtpMulticash");
            string url = conf.GetSection("Url").Value;
            string ftpController= conf.GetSection("Controller").Value;
            string ftpMethod= conf.GetSection("DownloadFileFromServer").Value;
            
            var objData = new
            {
                FtpPath = path,
                FileName = fileName,
                Username = conf.GetSection("FtpMulticash").GetSection("UserName").Value,
                Password = conf.GetSection("FtpMulticash").GetSection("Password").Value
            };

            FtpServiceResponseDTO response = restService.PostRestServiceAsync<FtpServiceResponseDTO>(url, 
                                                                                                    ftpController,
                                                                                                    ftpMethod,
                                                                                                    objData,
                                                                                                    new Dictionary<string, string>()).Result;

            if (response.Data != null)
            {
                result = (byte[])response.Data;
            }

            return result;
        }

        #endregion
    }
}
