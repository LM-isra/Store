using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Cannabis.Infrastructure.Data.Context;

public partial class StoreContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlite(_config.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                var dateTimeProperties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset));

                foreach (var property in properties)
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();

                foreach (var property in dateTimeProperties)
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
            }
        }
    }
}

