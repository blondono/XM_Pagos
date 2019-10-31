using System;
using System.Linq;
using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes       

        private readonly Context.Context _context;
        private bool disposed = false;
        #endregion


        #region Constructor
        public UnitOfWork(Context.Context context)
        {
            this._context = context;
        }
        #endregion


        #region Attributes


        #region Load

        // private Repository<LoadLatestExpirationEntity> loadLatestExpirationRepository;

        #endregion


        #endregion


        #region  Members

        //public Repository<LoadLatestExpirationEntity> LoadLatestExpirationRepository
        //{
        //    get
        //    {
        //        if (this.loadLatestExpirationRepository == null)
        //            this.loadLatestExpirationRepository = new Repository<LoadLatestExpirationEntity>(_context);

        //        return loadLatestExpirationRepository;
        //    }
        //}

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
