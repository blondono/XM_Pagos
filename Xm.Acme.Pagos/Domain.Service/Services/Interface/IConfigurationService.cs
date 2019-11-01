using System;
using System.Collections.Generic;
using System.Text;
using Domain.Service.DTO.Crossing;

namespace Domain.Service.Services.Interface
{
    public interface IConfigurationService
    {
        List<DateTime> GetDateExpirationByBusiness(string business, string token);
        List<string> GetAgentBeneficiary(LoadBeneficiaryFiltersDTO filters, string token);
    }
}
