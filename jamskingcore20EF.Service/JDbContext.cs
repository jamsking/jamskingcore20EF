using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;

namespace jamskingcore20EF.Service
{
    public class JDbContext:DbContext
    {
        public JDbContext(DbContextOptions<JDbContext> options) : base(options)
          {
  
          }
          public DbSet<Model.Model.tb_User> UserExtend { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            base.OnModelCreating(modelBuilder);
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);

            }
        }
}
}
