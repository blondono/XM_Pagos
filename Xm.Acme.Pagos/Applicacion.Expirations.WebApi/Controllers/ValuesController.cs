using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applicacion;
using Applicacion.Pagos;
using Applicacion.Pagos.WebApi;
using Applicacion.Pagos.WebApi.Controllers;
using AutoMapper;
using Common.Utils.Utils.Interface;
using Infraestructure.Core.Context;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Applicacion.Pagos.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        #region Attributes            
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeaderClaims _headerClaims;
        private string userName;

        #endregion


        #region Constructor
        public ValuesController(IHeaderClaims headerClaims, IUnitOfWork unitOfWork)
        {
            _headerClaims = headerClaims;
            this._unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        #endregion
    }
}