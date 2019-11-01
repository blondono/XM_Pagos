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

        [HttpPost("GetStampRequest")]
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

        #endregion

        #region Type Crossings

        #endregion

        #endregion
    }
}