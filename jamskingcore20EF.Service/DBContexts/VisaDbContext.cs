using Microsoft.EntityFrameworkCore;
using jamskingcore20EF.Model.VisaModels;
using jamskingcore20EF.Service.VisaMap;

namespace jamskingcore20EF.Service.DBContexts
{
    public class VisaDbContext : DbContext
    {
        public VisaDbContext(DbContextOptions<VisaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new VisaAccountMap(modelBuilder.Entity<DbVisaapiVisaAccount>());
            new VisaAccountFMMap(modelBuilder.Entity<DbVisaapiVisaAccountFM>());
            new VisaAccountPTMap(modelBuilder.Entity<DbVisaapiVisaAccountPT>());
            new VisaAccountTripMap(modelBuilder.Entity<DbVisaapiVisaAccountTrip>());
            new VisaConMap(modelBuilder.Entity<DbVisaapiVisaCon>());
            new VisaFileMap(modelBuilder.Entity<DbVisaapiVisaFile>());
            new VisaInfMap(modelBuilder.Entity<DbVisaapiVisaInf>());
            new VisaToDoMap(modelBuilder.Entity<DbVisaapiVisaToDo>());
            new VisaToDoBatchMap(modelBuilder.Entity<DbVisaapiVisaToDoBatch>());
        }
    }
}
