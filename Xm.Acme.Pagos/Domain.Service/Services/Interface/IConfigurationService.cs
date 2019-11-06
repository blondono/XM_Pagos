using Domain.Service.DTO.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Services.Interface
{
    public interface IConfigurationService
    {
        List<AccountBankResponseDTO> GetListBankAccount();
    }
}
