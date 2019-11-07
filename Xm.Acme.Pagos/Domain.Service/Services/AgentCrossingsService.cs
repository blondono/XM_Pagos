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

                DateTime dueDate = configurationService.GetDateExpirationByBusiness(agentCrossingsDTO.Business, token).FirstOrDefault();

                // Rule 6: The Initial Term will be the first day of the selected expiration and the Final Term will be the last calendar day of the selected expiration month.
                DateTime InitialValidity = dueDate;
                DateTime FinalValidity = new DateTime(InitialValidity.Year, InitialValidity.Month, DateTime.DaysInMonth(InitialValidity.Year, InitialValidity.Month));

                // Rule 1: Uniqueness. The system must validate that when there is duplicity a message is sent. To control duplicity you must validate: Business. Agent. Cross Type
                if (this.unitOfWork.AgentCrossingsRepository.FindAll(x => x.CrossingsEntity.Company == agentCrossingsDTO.Company
                                                                    && agentCrossingsDTO.Agent.Any(s => s == x.Agent)
                                                                    && x.CrossingsEntity.TypeCrossingId == agentCrossingsDTO.TypeCrossingId
                                                                    && x.CrossingsEntity.Enabled
                                                                    , ac => ac.CrossingsEntity).Count() > 0)
                    lstMessages.Add(AgentValidation.Uniqueness);

                // Rule 7, Rule 10: If the crossing that is created is after the initial date of the current expiration, ACME should not automatically allow you to create the record. You should show a message indicating that the crossing for that date is not possible.
                if (DateTime.Now >= InitialValidity)
                    lstMessages.Add(AgentValidation.CeatedInvalid);


                if (lstMessages.Count == 0)
                {

                    CrossingsEntity entity = new CrossingsEntity()
                    {
                        Company = agentCrossingsDTO.Company,
                        Business = agentCrossingsDTO.Business,
                        TypeCrossingId = agentCrossingsDTO.TypeCrossingId,
                        Value = agentCrossingsDTO.Value,
                        DueDate = agentCrossingsDTO.DueDate,
                        InitialValidity = InitialValidity,
                        FinalValidity = FinalValidity,
                        CreationDate = DateTime.Now,
                        CreationUser = user,
                        Enabled = true
                    };

                    entity.AgentCrossingsEntities = new List<AgentCrossingsEntity>()
                    {
                        new AgentCrossingsEntity()
                        {
                            Agent = agentCrossingsDTO.Agent[0],
                            CreationDate = DateTime.Now,
                            CreationUser = user
                        }
                    };

                    this.unitOfWork.CrossingsRepository.Insert(entity);
                    this.unitOfWork.Save();

                    isValid = true;
                    lstMessages = new List<string>();
                    lstMessages.Add(AgentValidation.Successfull);

                    // Rule 8: When the Agents enter crosses, the system must check if there is a due date charged and if for that expiration the agent that enters has a benefit. If you do not have it, you must notify it by means of an alert message and also by email
                    if (!GetAgentBeneficiary(agentCrossingsDTO.Agent[0], agentCrossingsDTO.Business, token))
                        lstMessages.Add(string.Format(AgentValidation.IsNotBeneficiary, agentCrossingsDTO.Agent[0], dueDate.ToString("yyyy-MM-dd"), agentCrossingsDTO.Business));

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
                DateTime dueDate = configurationService.GetDateExpirationByBusiness(agentCrossingsDTO.Business, token).FirstOrDefault();

                // Rule 1: Uniqueness. The system must validate that when there is duplicity a message is sent. To control duplicity you must validate: Business. Agent. Cross Type
                if (this.unitOfWork.AgentCrossingsRepository.FindAll(x => x.CrossingsEntity.Company == agentCrossingsDTO.Company
                                                                    && agentCrossingsDTO.Agent.Any(s => s == x.Agent)
                                                                    && x.CrossingsEntity.TypeCrossingId == agentCrossingsDTO.TypeCrossingId
                                                                    && x.CrossingsEntity.Enabled
                                                                    , ac => ac.CrossingsEntity).Count() > 0)
                    lstMessages.Add(AgentValidation.Uniqueness);

                // Rule 6, Rule 10: If the crossing that is created is after the initial date of the current expiration, ACME should not automatically allow you to create the record. You should show a message indicating that the crossing for that date is not possible.
                if (DateTime.Now >= dueDate)
                    lstMessages.Add(AgentValidation.CeatedInvalid);


                if (lstMessages.Count == 0)
                {
                    CrossingsEntity entity = new CrossingsEntity()
                    {
                        Company = agentCrossingsDTO.Company,
                        Business = agentCrossingsDTO.Business,
                        TypeCrossingId = agentCrossingsDTO.TypeCrossingId,

                        // Rule 16
                        Value = (agentCrossingsDTO.FullPaymentDebts.HasValue && agentCrossingsDTO.FullPaymentDebts.Value ? 0 : agentCrossingsDTO.Value),
                        DueDate = agentCrossingsDTO.DueDate,
                        InitialValidity = dueDate,

                        // Rule 12
                        FinalValidity = (agentCrossingsDTO.FinalValidity.HasValue ? agentCrossingsDTO.FinalValidity.Value : new Nullable<DateTime>()),
                        CreationDate = DateTime.Now,
                        CreationUser = user,
                        Enabled = true
                    };

                    entity.AgentCrossingsEntities = agentCrossingsDTO.Agent.Select(x => new AgentCrossingsEntity()
                                                                                {
                                                                                    Agent = x, 
                                                                                    CreationDate = DateTime.Now,
                                                                                    CreationUser = user
                                                                                }).ToList();

                    this.unitOfWork.CrossingsRepository.Insert(entity);
                    this.unitOfWork.Save();

                    isValid = true;
                    lstMessages = new List<string>();

                    // Rule 8
                    lstMessages.Add(AgentValidation.Successfull);

                    // Rule 7: When the Agents enter crosses, the system must check if there is a due date charged and if for that expiration the agent that enters has a benefit. If you do not have it, you must notify it by means of an alert message and also by email
                    if (!GetAgentBeneficiary(agentCrossingsDTO.Agent[0], agentCrossingsDTO.Business, token))
                        lstMessages.Add(string.Format(AgentValidation.IsNotBeneficiary, agentCrossingsDTO.Agent, dueDate.ToString("yyyy-MM-dd"), agentCrossingsDTO.Business));
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

        public bool GetAgentBeneficiary(string agent, string business, string token)
        {
            DateTime dueDate = configurationService.GetDateExpirationByBusiness(business, token).FirstOrDefault();

            LoadBeneficiaryFiltersDTO filters = new LoadBeneficiaryFiltersDTO()
            {
                Bussiness = business,
                DateExpiration = dueDate
            };
            string isBeneficiary = configurationService.GetAgentBeneficiary(filters, token).Find(x => x == agent);
            return !string.IsNullOrEmpty(isBeneficiary);
        }

        /// <summary>
        /// update a Agent Crossing record
        /// </summary>
        /// <param name="agentCrossingsId">agentCrossingsId</param>
        /// <param name="user">user</param>
        /// <returns>bool</returns>
        public bool DeleteAgentCrossing(int crossingsId, string user)
        {
            CrossingsEntity entity = this.unitOfWork.CrossingsRepository.Find(x => x.CrossingId == crossingsId);
            entity.Enabled = false;
            entity.ModificationDate = DateTime.Now;
            entity.ModificationUser = user;
            this.unitOfWork.CrossingsRepository.Update(entity);
            return this.unitOfWork.Save() > 0;
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
                IEnumerable<AgentCrossingsResultDTO> agentCrossingsDTOs = this.unitOfWork.AgentCrossingsRepository.FindAll(ac => ac.CrossingsEntity.Business.ToLower().Contains((string.IsNullOrEmpty(filters.Business) ? ac.CrossingsEntity.Business.ToLower() : filters.Business.ToLower()))
                                                                                                                            && ac.Agent.ToLower().Contains((string.IsNullOrEmpty(filters.Agent) ? ac.Agent.ToLower() : filters.Agent.ToLower()))
                                                                                                                            && ac.CrossingsEntity.TypeCrossingId == (filters.TypeCrossingId == 0 ? ac.CrossingsEntity.TypeCrossingId : filters.TypeCrossingId)
                                                                                                                            && ac.CrossingsEntity.DueDate.ToString("yyyy-MM-dd") == (string.IsNullOrEmpty(filters.DueDate) ? ac.CrossingsEntity.DueDate.ToString("yyyy-MM-dd") : filters.DueDate)
                                                                                                                            && ac.CrossingsEntity.Enabled
                                                                                                                            , ac => ac.CrossingsEntity.TypeCrossingsEntity)
                    .OrderByDescending(ob => ob.CreationDate)
                    .Select(g => new AgentCrossingsResultDTO()
                    {
                        Agent = g.Agent,
                        AgentCrossingId = g.AgentCrossingId,
                        Business = g.CrossingsEntity.Business,
                        Company = g.CrossingsEntity.Company,
                        Crossed = g.CrossingsEntity.Crossed,
                        DueDate = g.CrossingsEntity.DueDate.ToString("yyyy-MM-dd"),
                        FinalValidity = (g.CrossingsEntity.FinalValidity.HasValue ? g.CrossingsEntity.FinalValidity.Value.ToString("yyyy-MM-dd") : string.Empty),
                        InitialValidity = g.CrossingsEntity.InitialValidity.ToString("yyyy-MM-dd"),
                        TypeCrossing = g.CrossingsEntity.TypeCrossingsEntity.Name,
                        TypeCrossingId = g.CrossingsEntity.TypeCrossingId
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
