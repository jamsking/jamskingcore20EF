using Microsoft.EntityFrameworkCore;
using jamskingcore20EF.Model.ApiModels;
using jamskingcore20EF.Service.ApiMap;

namespace jamskingcore20EF.Service.DBContexts
{
    public class BaseApiDbContext : DbContext
    {
        
        public BaseApiDbContext(DbContextOptions<BaseApiDbContext> options) : base(options)
        {
        }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ApiAccountMap(modelBuilder.Entity<ApiAccount>());
            new ApiAccountGroupMap(modelBuilder.Entity<ApiAccountGroup>());
            new ResponseStatusMap(modelBuilder.Entity<ResponseStatus>());

        }
    }
}
