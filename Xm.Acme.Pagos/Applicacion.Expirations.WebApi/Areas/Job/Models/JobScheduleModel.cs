using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicacion.IntegrationOracle.WebApi.Areas.Job.Models
{
    public class JobScheduleModel
    {
        public JobScheduleModel(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }

        public Type JobType { get; }
        public string CronExpression { get; }
    }
}
