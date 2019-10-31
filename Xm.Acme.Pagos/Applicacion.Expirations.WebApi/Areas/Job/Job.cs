using AutoMapper;
using Infraestructure.Core.UnitOfWork;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicacion.IntegrationOracle.WebApi.Areas.Job
{
    [DisallowConcurrentExecution]
    public class Job : IJob
    {

        #region Atributes       

        #endregion


        #region Constructor
        public Job()
        {
           
        }
        #endregion


        #region Methods
        public Task Execute(IJobExecutionContext context)
        {           

            return Task.CompletedTask;
        }

        #endregion
    }
}
