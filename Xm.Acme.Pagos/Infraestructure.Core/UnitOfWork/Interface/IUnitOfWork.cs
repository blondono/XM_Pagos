using System;
using Infraestructure.Core.Repository;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        #region Load

         //Repository<LoadLatestExpirationEntity> LoadLatestExpirationRepository { get;  }
        #endregion


        new void Dispose();

        int Save();
    }
}
