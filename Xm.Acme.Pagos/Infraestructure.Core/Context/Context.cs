using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        {
        }


        #region DbSet Entities      

        
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
     }
}
