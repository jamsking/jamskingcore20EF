using Microsoft.EntityFrameworkCore;
using jamskingcore20EF.Model.Model;
using jamskingcore20EF.Service.Map;

namespace jamskingcore20EF.Service.DBContexts
{
    public class JADbContext : DbContext
    {
        public JADbContext(DbContextOptions<JADbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new BookMap(modelBuilder.Entity<Book>());
        }
    }
}
