using Infraestructure.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        {
        }


        #region DbSet Entities      

        #region Crossing
        public DbSet<TypeCrossingsEntity> TypeCrossingsEntity { get; set; }
        public DbSet<AgentCrossingsEntity> AgentCrossingsEntity { get; set; }
        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
     }
}
