using Domain.Service.Services.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Services.Strategy.Behaviors
{
    public class ProcessOccidente : ProcessFileBankMovement
    {
        #region Atributes

        public readonly IFtpFileService ftpFileService;
        public readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructor
        public ProcessOccidente(IFtpFileService pFtpFileService, IUnitOfWork pUnitOfWork)
        {
            this.ftpFileService = pFtpFileService;
            this.unitOfWork = pUnitOfWork;
        }
        #endregion

        #region Methods

        #region Public Methods

        public override void ProcessBankFile()
        {
            var a = unitOfWork;
            var b = ftpFileService;
        }

        public override void ValidateProcessOccidente()
        {
            var a = unitOfWork;
            var b = ftpFileService;
        }

        #endregion

        #region Private Methods



        #endregion
        #endregion
    }
}
