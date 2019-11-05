using System;
using Infraestructure.Core.Repository;
using Infraestructure.Entity.Entities.ProcessFile;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        #region ProcessFile

        Repository<BankFileAdminEntity> BankFileAdminRepository { get;  }

        #endregion


        new void Dispose();

        int Save();
    }
}
