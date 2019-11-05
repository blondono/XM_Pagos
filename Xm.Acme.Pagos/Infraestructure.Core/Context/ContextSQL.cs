using Infraestructure.Entity.Entities.ProcessFile;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Context
{
    public class ContextSQL : DbContext
    {
        public ContextSQL(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        {
        }


        #region DbSet Entities      

        public DbSet<BankFileAdminEntity> BankFileAdminEntities { get; set; } 
        
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
     }
}
