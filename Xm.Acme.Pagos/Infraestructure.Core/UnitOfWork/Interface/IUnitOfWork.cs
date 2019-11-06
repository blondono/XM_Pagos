using System;
using Infraestructure.Core.Repository;
using Infraestructure.Entity.Entities;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        #region AgentCrossings

        Repository<TypeCrossingsEntity> TypeCrossingsRepository { get; }
        Repository<AgentCrossingsEntity> AgentCrossingsRepository { get; }
        Repository<CrossingsEntity> CrossingsRepository { get; }

        #endregion

        #region Load

        //Repository<LoadLatestExpirationEntity> LoadLatestExpirationRepository { get;  }
        #endregion


        new void Dispose();

        int Save();
    }
}
