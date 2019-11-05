using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Utils.Constant;
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
        public readonly IConfigurationService configurationService;

        #endregion

        #region Builder

        public AgentCrossingsService(IUnitOfWork iUnitOfWork, IConfigurationService iConfigurationService)
        {
            this.unitOfWork = iUnitOfWork;
            this.configurationService = iConfigurationService;
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
        public AgentCrossingsResponseDTO InsertCustodyAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user, string token)
        {
            bool isValid = false;
            List<string> lstMessages = new List<string>();
            AgentCrossingsResponseDTO responseDTO;
            try
            {
                lstMessages = ValidateAgentCrossing(agentCrossingsDTO, user, token);

                if (lstMessages.Count == 0)
                {
                    DateTime dueDate = configurationService.GetDateExpirationByBusiness(agentCrossingsDTO.Business, token).FirstOrDefault();

                    // Rule 6: The Initial Term will be the first day of the selected expiration and the Final Term will be the last calendar day of the selected expiration month.
                    DateTime InitialValidity = dueDate;
                    DateTime FinalValidity = new DateTime(InitialValidity.Year, InitialValidity.Month, DateTime.DaysInMonth(InitialValidity.Year, InitialValidity.Month));

                    AgentCrossingsEntity entity = new AgentCrossingsEntity()
                    {
                        Company = agentCrossingsDTO.Company,
                        Business = agentCrossingsDTO.Business,
                        Agent = agentCrossingsDTO.Agent,
                        TypeCrossingId = agentCrossingsDTO.TypeCrossingId,
                        Value = agentCrossingsDTO.Value,
                        DueDate = agentCrossingsDTO.DueDate,
                        InitialValidity = InitialValidity,
                        FinalValidity = FinalValidity,
                        CreationDate = DateTime.Now,
                        CreationUser = user
                    };
                    this.unitOfWork.AgentCrossingsRepository.Insert(entity);
                    this.unitOfWork.Save();
                    isValid = true;
                    lstMessages = new List<string>();
                    lstMessages.Add(AgentValidation.Successfull);
                }
                responseDTO = new AgentCrossingsResponseDTO()
                {
                    IsValid = isValid,
                    Messages = lstMessages
                };
                return responseDTO;
            }
            catch (BusinessExeption ex)
            {
                throw new BusinessExeption("Fallo al consultar", ex);
            }
            catch (Exception ex)
            {
                throw new BusinessExeption("Fallo al consultar", ex);
            }
        }

        /// <summary>
        /// Create a Agent Crossing record
        /// </summary>
        /// <param name="agentCrossingsDTO"></param>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public AgentCrossingsResponseDTO InsertDebtAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user, string token)
        {
            List<string> lstMessages = new List<string>();
            AgentCrossingsResponseDTO responseDTO;
            bool isValid = false;
            try
            {
                lstMessages = ValidateAgentCrossing(agentCrossingsDTO, user, token);
                if (lstMessages.Count == 0)
                {
                    DateTime dueDate = configurationService.GetDateExpirationByBusiness(agentCrossingsDTO.Business, token).FirstOrDefault();

                    // Rule 6: The Initial Term will be the first day of the selected expiration and the Final Term will be the last calendar day of the selected expiration month.
                    DateTime InitialValidity = dueDate;

                    AgentCrossingsEntity entity = new AgentCrossingsEntity()
                    {
                        Company = agentCrossingsDTO.Company,
                        Business = agentCrossingsDTO.Business,
                        Agent = agentCrossingsDTO.Agent,
                        TypeCrossingId = agentCrossingsDTO.TypeCrossingId,
                        Value = (agentCrossingsDTO.FullPaymentDebts.HasValue && agentCrossingsDTO.FullPaymentDebts.Value ? 0 : agentCrossingsDTO.Value),
                        DueDate = agentCrossingsDTO.DueDate,
                        InitialValidity = InitialValidity,
                        FinalValidity = agentCrossingsDTO.FinalValidity,
                        CreationDate = DateTime.Now,
                        CreationUser = user
                    };
                    this.unitOfWork.AgentCrossingsRepository.Insert(entity);
                    this.unitOfWork.Save();
                    isValid = true;
                    lstMessages = new List<string>();
                    lstMessages.Add(AgentValidation.Successfull);
                }
                responseDTO = new AgentCrossingsResponseDTO()
                {
                    IsValid = isValid,
                    Messages = lstMessages
                };
                return responseDTO;
            }
            catch (BusinessExeption ex)
            {
                throw new BusinessExeption("Fallo al consultar", ex);
            }
            catch (Exception ex)
            {
                throw new BusinessExeption("Fallo al consultar", ex);
            }
        }

        public List<string> ValidateAgentCrossing(AgentCrossingsDTO agentCrossingsDTO, string user, string token)
        {

            List<string> lstMessages = new List<string>();
            try
            {
                DateTime dueDate = configurationService.GetDateExpirationByBusiness(agentCrossingsDTO.Business, token).FirstOrDefault();

                // Rule 6: The Initial Term will be the first day of the selected expiration and the Final Term will be the last calendar day of the selected expiration month.
                DateTime InitialValidity = dueDate;
                DateTime FinalValidity = new DateTime(InitialValidity.Year, InitialValidity.Month, DateTime.DaysInMonth(InitialValidity.Year, InitialValidity.Month));

                // Rule 1: Uniqueness. The system must validate that when there is duplicity a message is sent. To control duplicity you must validate: Business. Agent. Cross Type
                if (this.unitOfWork.AgentCrossingsRepository.FindAll(x => x.Company == agentCrossingsDTO.Company && x.Agent == agentCrossingsDTO.Agent && x.TypeCrossingId == agentCrossingsDTO.TypeCrossingId).Count() > 0)
                    lstMessages.Add(AgentValidation.Uniqueness);

                // Rule 7, Rule 10: If the crossing that is created is after the initial date of the current expiration, ACME should not automatically allow you to create the record. You should show a message indicating that the crossing for that date is not possible.
                if (DateTime.Now > InitialValidity)
                    lstMessages.Add(AgentValidation.CeatedInvalid);

                // Rule 8: When the Agents enter crosses, the system must check if there is a due date charged and if for that expiration the agent that enters has a benefit. If you do not have it, you must notify it by means of an alert message and also by email
                LoadBeneficiaryFiltersDTO filters = new LoadBeneficiaryFiltersDTO()
                {
                    Bussiness = agentCrossingsDTO.Business,
                    DateExpiration = dueDate
                };
                string isBeneficiary = configurationService.GetAgentBeneficiary(filters, token).Find(x => x == agentCrossingsDTO.Agent);
                if (string.IsNullOrEmpty(isBeneficiary))
                    lstMessages.Add(string.Format(AgentValidation.IsNotBeneficiary, agentCrossingsDTO.Agent, dueDate.ToString("yyyy-MM-dd"), agentCrossingsDTO.Business));

                return lstMessages;
            }
            catch (BusinessExeption ex)
            {
                throw new BusinessExeption("Fallo al consultar", ex);
            }
            catch (Exception ex)
            {
                throw new BusinessExeption("Fallo al consultar", ex);
            }
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
        public IEnumerable<AgentCrossingsResultDTO> GetAgentCrossing(AgentCrossingsFilterDTO filters)
        {
            try
            {
                IEnumerable<AgentCrossingsResultDTO> agentCrossingsDTOs = this.unitOfWork.AgentCrossingsRepository.FindAll(ac => ac.Business.ToLower().Contains((string.IsNullOrEmpty(filters.Business) ? ac.Business.ToLower() : filters.Business.ToLower()))
                                                                                                                            && ac.Agent.ToLower().Contains((string.IsNullOrEmpty(filters.Agent) ? ac.Agent.ToLower() : filters.Agent.ToLower()))
                                                                                                                            && ac.TypeCrossingId == (filters.TypeCrossingId == 0 ? ac.TypeCrossingId : filters.TypeCrossingId)
                                                                                                                            && ac.DueDate.ToString("yyyy-MM-dd") == (string.IsNullOrEmpty(filters.DueDate) ? ac.DueDate.ToString("yyyy-MM-dd") : filters.DueDate)
                                                                                                                            , ac => ac.TypeCrossingsEntity)
                    .OrderByDescending(ob => ob.CreationDate)
                    .Select(g => new AgentCrossingsResultDTO()
                    {
                        Agent = g.Agent,
                        AgentCrossingId = g.AgentCrossingId,
                        Business = g.Business,
                        Company = g.Company,
                        Crossed = g.Crossed,
                        DueDate = g.DueDate.ToString("yyyy-MM-dd"),
                        FinalValidity = g.FinalValidity.ToString("yyyy-MM-dd"),
                        InitialValidity = g.InitialValidity.ToString("yyyy-MM-dd"),
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
