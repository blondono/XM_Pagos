using System;
using System.Linq;
using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes       

        private readonly Context.DBContext _context;
        private bool disposed = false;
        #endregion


        #region Constructor
        public UnitOfWork(DBContext context)
        {
            this._context = context;
        }
        #endregion


        #region Attributes


        #region Crossing
        private Repository<TypeCrossingsEntity> typeCrossingsRepository;
        private Repository<AgentCrossingsEntity> agentCrossingsRepository;
        private Repository<CrossingsEntity> crossingsRepository;
        #endregion

        #region Load

        // private Repository<LoadLatestExpirationEntity> loadLatestExpirationRepository;

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
