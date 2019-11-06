using System;
using System.Linq;
using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Entities.ProcessFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes       

        private readonly ContextSQL _context;
        private bool disposed = false;
        private readonly IServiceProvider serv;
        #endregion


        #region Constructor
        public UnitOfWork(IServiceProvider serv)
        {
            var serviceScope = serv.CreateScope();
            this._context = new ContextSQL(serviceScope.ServiceProvider.GetRequiredService<DbContextOptions<ContextSQL>>());
        }
        #endregion


        #region Attributes


        #region ProcessFile

        private Repository<FileAdministratorEntity> fileAdministratorRepository;
        private Repository<FileDataEntity> fileDataRepository;
        private Repository<FileDataDetailEntity> fileDataDetailRepository;
        private Repository<EquivalenceColumnEntity> equivalenceColumnRepository;

        #endregion


        #endregion


        #region  Members

        #region ProcessFile

        public Repository<FileAdministratorEntity> FileAdministratorRepository
        {
            get
            {
                if (this.fileAdministratorRepository == null)
                    this.fileAdministratorRepository = new Repository<FileAdministratorEntity>(_context);

                return fileAdministratorRepository;
            }
        }

        public Repository<FileDataEntity> FileDataRepository
        {
            get
            {
                if (this.fileDataRepository == null)
                    this.fileDataRepository = new Repository<FileDataEntity>(_context);

                return fileDataRepository;
            }
        }

        public Repository<FileDataDetailEntity> FileDataDetailRepository
        {
            get
            {
                if (this.fileDataDetailRepository == null)
                    this.fileDataDetailRepository = new Repository<FileDataDetailEntity>(_context);

                return fileDataDetailRepository;
            }
        }

        public Repository<EquivalenceColumnEntity> EquivalenceColumnRepository
        {
            get
            {
                if (this.equivalenceColumnRepository == null)
                    this.equivalenceColumnRepository = new Repository<EquivalenceColumnEntity>(_context);

                return equivalenceColumnRepository;
            }
        }
        #endregion

        #endregion


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save() => _context.SaveChanges();

    }
}
