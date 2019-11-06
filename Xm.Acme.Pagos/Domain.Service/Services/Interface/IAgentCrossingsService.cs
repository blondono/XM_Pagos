using System;
using System.Collections.Generic;
using System.Text;
using Domain.Service.DTO.Crossing;

namespace Domain.Service.Services.Interface
{
    public interface IAgentCrossingsService
    {
        #region AgentCrossings

        /// <summary>
        /// Create a Agent Crossing custody
        /// </summary>
        /// <param name="agentCrossingsDTO">agentCrossingsDTO</param>
        /// <param name="user">user</param>
        /// <param name="token"></param>
        /// <returns>bool</returns>
        AgentCrossingsResponseDTO InsertCustodyAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user, string token);

        /// <summary>
        /// update a Agent Crossing record
        /// </summary>
        /// <param name="agentCrossingsDTO">agentCrossingsDTO</param>
        /// <param name="user">user</param>
        /// <returns>bool</returns>
        bool UpdateAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user);

        /// <summary>
        /// update a Agent Crossing record
        /// </summary>
        /// <param name="crossingsId">crossingsId</param>
        /// <param name="user">user</param>
        /// <returns>bool</returns>
        bool DeleteAgentCrossing(int crossingsId, string user);

        /// <summary>
        /// Get all Agent Crossings by filters
        /// </summary>
        /// <param name="filters">AgentCrossingsFilterDTO</param>
        /// <returns>List<AgentCrossingsDTO></returns>
        IEnumerable<AgentCrossingsResultDTO> GetAgentCrossing(AgentCrossingsFilterDTO filters);

        /// <summary>
        /// Create a agent crossing debt
        /// </summary>
        /// <param name="agentCrossingsDTO"></param>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        AgentCrossingsResponseDTO InsertDebtAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user, string token);

        /// <summary>
        /// Return if agent is beneficiary
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="business"></param>
        /// <param name="dueDate"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        bool GetAgentBeneficiary(string agent, string business, string token);

        #endregion

        #region TypeCrossings

        /// <summary>
        /// Get all TypeCrossings
        /// </summary>
        /// <returns> List<TypeCrossingsDTO></returns>
        List<TypeCrossingsDTO> GetTypeCrossings();

        #endregion
    }
}
