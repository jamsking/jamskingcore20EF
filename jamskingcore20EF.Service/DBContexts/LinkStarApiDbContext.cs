using Microsoft.EntityFrameworkCore;
using jamskingcore20EF.Model.LinkStarApiModels;
using jamskingcore20EF.Service.LinkStarApiMap;

namespace jamskingcore20EF.Service.DBContexts
{
    public class LinkStarApiDbContext : DbContext
    {
        public LinkStarApiDbContext(DbContextOptions<LinkStarApiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ReRecoderMap(modelBuilder.Entity<ReRecoder>());
            new UpRecoderMap(modelBuilder.Entity<UpRecoder>());
            
        }
    }
}
