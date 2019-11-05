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

        private Repository<BankFileAdminEntity> bankFileAdminRepository;

        #endregion


        #endregion


        #region  Members

        #region ProcessFile
        public Repository<BankFileAdminEntity> BankFileAdminRepository
        {
            get
            {
                if (this.bankFileAdminRepository == null)
                    this.bankFileAdminRepository = new Repository<BankFileAdminEntity>(_context);

                return bankFileAdminRepository;
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
