using Infraestructure.Entity.Entities.AgentCrossings;
using Infraestructure.Entity.Entities.ProcessFile;
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
        public DbSet<CrossingsEntity> CrossingsEntity { get; set; }
        #endregion

        #region Process File      

        public DbSet<FileAdministratorEntity> FileAdministratorEntities { get; set; }

        public DbSet<FileDataEntity> FileDataEntities { get; }

        public DbSet<FileDataDetailEntity> FileDataDetailEntities { get; }

        public DbSet<EquivalenceColumnEntity> EquivalenceColumnEntities { get; }

        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
     }
}
