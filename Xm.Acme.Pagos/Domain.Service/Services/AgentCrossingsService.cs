using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Common.Utils.Excepcions;
using Domain.Service.DTO.Crossing;
using Domain.Service.Services.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Entities;

namespace Domain.Service.Services
{
    public class AgentCrossingsService : IAgentCrossingsService
    {
        #region Members

        public readonly IUnitOfWork unitOfWork;

        #endregion

        #region Builder

        public AgentCrossingsService(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
        }

        #endregion

        #region Methods

        #region AgentCrossings

        /// <summary>
        /// Create a Agent Crossing record
        /// </summary>
        /// <param name="agentCrossingsDTO">agentCrossingsDTO</param>
        /// <param name="user">user</param>
        /// <returns>bool</returns>
        public bool InsertAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update a Agent Crossing record
        /// </summary>
        /// <param name="agentCrossingsDTO">agentCrossingsDTO</param>
        /// <param name="user">user</param>
        /// <returns>bool</returns>
        public bool UpdateAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update a Agent Crossing record
        /// </summary>
        /// <param name="agentCrossingsId">agentCrossingsId</param>
        /// <param name="user">user</param>
        /// <returns>bool</returns>
        public bool DeleteAgentCrossing(int agentCrossingsId, string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all Agent Crossings by filters
        /// </summary>
        /// <param name="filters">AgentCrossingsFilterDTO</param>
        /// <returns>List<AgentCrossingsDTO></returns>
        public IEnumerable<AgentCrossingsDTO> GetAgentCrossing(AgentCrossingsFilterDTO filters)
        {
            try
            {
                IEnumerable<AgentCrossingsDTO> agentCrossingsDTOs = this.unitOfWork.AgentCrossingsRepository.FindAll(ac => ac.Business.ToLower().Contains((string.IsNullOrEmpty(filters.Business) ? ac.Business.ToLower() : filters.Business.ToLower()))
                                                                                                                            && ac.Agent.ToLower().Contains((string.IsNullOrEmpty(filters.Agent) ? ac.Agent.ToLower() : filters.Agent.ToLower()))
                                                                                                                            && ac.TypeCrossingId == (filters.TypeCrossingId == 0 ? ac.TypeCrossingId : filters.TypeCrossingId)
                                                                                                                            && ac.DueDate.ToString("yyyy-MM-dd") == (string.IsNullOrEmpty(filters.DueDate) ? ac.DueDate.ToString("yyyy-MM-dd") : filters.DueDate)
                                                                                                                            , ac => ac.TypeCrossingsEntity)
                    .OrderByDescending(ob => ob.CreationDate)
                    .Select(g => new AgentCrossingsDTO()
                    {
                        Agent = g.Agent,
                        AgentCrossingId = g.AgentCrossingId,
                        Business = g.Business,
                        Company = g.Company,
                        Crossed = g.Crossed,
                        DueDate = g.DueDate,
                        FinalValidity = g.FinalValidity,
                        InitialValidity = g.InitialValidity,
                        TypeCrossing = g.TypeCrossingsEntity.Name,
                        TypeCrossingId = g.TypeCrossingId
                    }).Take(100);

                return agentCrossingsDTOs;
            }
            catch (BusinessExeption bex)
            {
                throw new BusinessExeption("Fallo al consultar", bex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al consultar", ex);
            }
        }

        #endregion

        #region TypeCrossings

        /// <summary>
        /// Get all TypeCrossings
        /// </summary>
        /// <returns>List<TypeCrossingsDTO></returns>
        public List<TypeCrossingsDTO> GetTypeCrossings()
        {
            List<TypeCrossingsDTO> TypeCrossingsDTOs = new List<TypeCrossingsDTO>();
            try
            {
                IEnumerable<TypeCrossingsEntity> typeCrossingsEntities = this.unitOfWork.TypeCrossingsRepository.GetAll();

                TypeCrossingsDTOs = Mapper.Map<List<TypeCrossingsDTO>>(typeCrossingsEntities.ToList());

                return TypeCrossingsDTOs;
            }
            catch (BusinessExeption bex)
            {
                throw new BusinessExeption("Fallo al consultar", bex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al consultar", ex);
            }
        }

        #endregion

        #endregion
    }
}
