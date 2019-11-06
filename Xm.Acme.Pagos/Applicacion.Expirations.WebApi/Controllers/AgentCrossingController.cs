using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Utils.Utils.Interface;
using Domain.Service.DTO.Crossing;
using Domain.Service.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Applicacion.Pagos.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentCrossingController : ControllerBase
    {
        #region Attributes

        private readonly IAgentCrossingsService agentCrossingsService;
        private readonly IHeaderClaims headerClaims;
        private string userName;

        #endregion

        #region Constructor

        public AgentCrossingController(IAgentCrossingsService iAgentCrossingsService, IHeaderClaims headerClaims)
        {
            this.agentCrossingsService = iAgentCrossingsService;
            this.headerClaims = headerClaims;
        }

        #endregion

        #region Methods

        #region Agent Crossings

        [HttpGet("GetAgentActive")]
        public IActionResult GetAgentActive(string agent, string business)
        {
            HttpResponse response;

            try
            {
                string token = Request.Headers["Authorization"];
                bool result = agentCrossingsService.GetAgentBeneficiary(agent, business, token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get all agent crossings  by filters
        /// </summary>
        /// <param name="filters">AgentCrossingsFilterDTO</param>
        /// <returns>AgentCrossingsResultDTO</returns>
        [HttpPost("GetAgentCrossing")]
        public IActionResult GetAgentCrossing(AgentCrossingsFilterDTO filters)
        {
            HttpResponse response;

            try
            {
                IEnumerable<AgentCrossingsResultDTO> result = agentCrossingsService.GetAgentCrossing(filters);

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert a custody agent crossing in the database
        /// </summary>
        /// <param name="agentCrossingsDTO">AgentCrossingsDTO</param>
        /// <returns>AgentCrossingsResponseDTO</returns>
        [HttpPost("InsertCustodyAgentCrossing")]
        public IActionResult InsertCustodyAgentCrossing(AgentCrossingsDTO agentCrossingsDTO)
        {
            HttpResponse response;
            try
            {
                string token = Request.Headers["Authorization"];
                string userName = this.headerClaims.GetUserNameAuth(Request.Headers["Authorization"]);
                AgentCrossingsResponseDTO result = agentCrossingsService.InsertCustodyAgentCrossing(agentCrossingsDTO, userName, token);

                if (result.IsValid)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert a custody agent crossing in the database
        /// </summary>
        /// <param name="agentCrossingsDTO">AgentCrossingsDTO</param>
        /// <returns>AgentCrossingsResponseDTO</returns>
        [HttpPost("InsertDebtAgentCrossing")]
        public IActionResult InsertDebtAgentCrossing(AgentCrossingsDTO agentCrossingsDTO)
        {
            HttpResponse response;
            try
            {
                string token = Request.Headers["Authorization"];
                string userName = this.headerClaims.GetUserNameAuth(Request.Headers["Authorization"]);
                AgentCrossingsResponseDTO result = agentCrossingsService.InsertDebtAgentCrossing(agentCrossingsDTO, userName, token);

                if (result.IsValid)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete agent crossing
        /// </summary>
        /// <param name="crossingId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAgentCrossing")]
        public IActionResult DeleteAgentCrossing(int crossingId)
        {
            HttpResponse response;
            try
            {
                userName = this.headerClaims.GetUserNameAuth(Request.Headers["Authorization"]);
                bool result = agentCrossingsService.DeleteAgentCrossing(crossingId, userName);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Type Crossings

        #endregion

        #endregion
    }
}