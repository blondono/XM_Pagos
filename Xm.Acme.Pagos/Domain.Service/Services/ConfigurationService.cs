using Domain.Service.DTO.Configuration;
using Domain.Service.Services.Interface;
using Infraestructure.Core.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Services
{
    public class ConfigurationService : IConfigurationService
    {

        #region Attributes
        public readonly IConfiguration configuration;
        public readonly IRestService restService;
        #endregion

        #region Constructor
        public ConfigurationService(IConfiguration configuration, IRestService restService)
        {
            this.configuration = configuration;
            this.restService = restService;
        }
        #endregion

        #region Methods


        public List<AccountBankResponseDTO> GetListBankAccount()
        {
            List<AccountBankResponseDTO> list = new List<AccountBankResponseDTO>();
            IConfiguration conf = configuration.GetSection("ConfigurationService");
            string url = conf.GetSection("Url").Value;
            IConfiguration listSection = conf.GetSection("BankAccounts");
            string listController = listSection.GetSection("Controller").Value;
            string listMethod = listSection.GetSection("consultarCuentasBancarias").Value;
            
            ConfigurationServiceResponseDTO<AccountBankResponseDTO> result =
            restService.GetRestServiceAsync<ConfigurationServiceResponseDTO<AccountBankResponseDTO>>((url + listController),
                                                                                                   listMethod,
                                                                                                   new Dictionary<string, string>(),
                                                                                                   new Dictionary<string, string>()).Result;
            if (restService != null && result.resultado.Count > 0)
            {
                list.AddRange(result.resultado);
            }

            return list;
        }

        #endregion
    }
}
