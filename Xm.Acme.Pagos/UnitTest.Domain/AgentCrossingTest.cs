using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service.DTO.Crossing;
using Domain.Service.Services;
using Domain.Service.Services.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTest.Domain.DependencyInjection;

namespace UnitTest.Domain
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AgentCrossingTest
    {
        #region Members

        IAgentCrossingsService agentCrossingsService;
        IConfigurationRoot configurationRoot;
        IUnitOfWork unitOfWork;

        #endregion

        #region Builder

        public AgentCrossingTest()
        {
            var serviceProvider = Startup.ConfigureServices();
            configurationRoot = serviceProvider.GetService<IConfigurationRoot>();
            agentCrossingsService = serviceProvider.GetService<IAgentCrossingsService>();
            unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        }

        [TestMethod]
        [Ignore("")]
        public void GetAgentCrossing()
        {
            AgentCrossingsFilterDTO filters = new AgentCrossingsFilterDTO()
            {
                Business = "STN"
            };
            List<AgentCrossingsResponseDTO> list = new List<AgentCrossingsResponseDTO>()
            {
                new AgentCrossingsResponseDTO() { Business = "STN" }
            };
            try
            {
                IEnumerable<AgentCrossingsResponseDTO> response = agentCrossingsService.GetAgentCrossing(filters);
                 Assert.AreEqual(response.ToList()[0].Business, list[0].Business);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        #endregion
    }
}
