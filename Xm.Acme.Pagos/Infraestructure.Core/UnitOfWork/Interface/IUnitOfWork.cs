using System;
using Infraestructure.Core.Repository;
using Infraestructure.Entity.Entities.ProcessFile;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        #region ProcessFile

        Repository<FileAdministratorEntity> FileAdministratorRepository { get; }

        Repository<FileDataEntity> FileDataRepository { get; }

        Repository<FileDataDetailEntity> FileDataDetailRepository { get; }

        Repository<EquivalenceColumnEntity> EquivalenceColumnRepository { get; }

        #endregion


        new void Dispose();

        int Save();
    }
}
