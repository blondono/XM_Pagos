using System;
using System.Linq;
using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Entities.ProcessFile;
using Infraestructure.Entity.Entities.AgentCrossings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes       

        private readonly Context.DBContext _context;
        private bool disposed = false;
        private readonly IServiceProvider serv;
        #endregion


        #region Constructor
        public UnitOfWork(IServiceProvider serv)
        {
            var serviceScope = serv.CreateScope();
            this._context = new DBContext(serviceScope.ServiceProvider.GetRequiredService<DbContextOptions<DBContext>>());
        }
        #endregion


        #region Attributes


        #region Crossing
        private Repository<TypeCrossingsEntity> typeCrossingsRepository;
        private Repository<AgentCrossingsEntity> agentCrossingsRepository;
        private Repository<CrossingsEntity> crossingsRepository;
        #endregion

        #region ProcessFile

        private Repository<FileAdministratorEntity> fileAdministratorRepository;
        private Repository<FileDataEntity> fileDataRepository;
        private Repository<FileDataDetailEntity> fileDataDetailRepository;
        private Repository<EquivalenceColumnEntity> equivalenceColumnRepository;

        #endregion


        #endregion


        #region  Members

        #region Crossing

        public Repository<TypeCrossingsEntity> TypeCrossingsRepository
        {
            get
            {
                if (this.typeCrossingsRepository == null)
                    this.typeCrossingsRepository = new Repository<TypeCrossingsEntity>(_context);

                return typeCrossingsRepository;
            }
        }

        public Repository<AgentCrossingsEntity> AgentCrossingsRepository
        {
            get
            {
                if (this.agentCrossingsRepository == null)
                    this.agentCrossingsRepository = new Repository<AgentCrossingsEntity>(_context);

                return agentCrossingsRepository;
            }
        }

        public Repository<CrossingsEntity> CrossingsRepository
        {
            get
            {
                if (this.crossingsRepository == null)
                    this.crossingsRepository = new Repository<CrossingsEntity>(_context);

                return crossingsRepository;
            }
        }

        #endregion

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
