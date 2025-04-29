using Microsoft.EntityFrameworkCore;

namespace MVC_XP.Infra
{
    public class MVCXPContext : DbContext
    {
        public MVCXPContext(DbContextOptions options) : base(options)
        {
        }

        protected virtual void ConfigureDefaultTypes(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                   .SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                {
                    property.SetColumnType("DECIMAL(18, 2)");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MVCXPContext).Assembly);
        }
    }
}
