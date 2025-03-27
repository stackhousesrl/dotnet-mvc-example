
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.DataContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public ApplicationDbContext() : base()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (!builder.IsConfigured)
        {
            string connectionStringSQL;

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connectionStringSQL = config.GetConnectionString("testDb");

            builder.UseSqlServer(connectionStringSQL);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.HasDefaultSchema("dbo");

        // builder.ApplyConfiguration(new DishConfiguration());
    }

}


