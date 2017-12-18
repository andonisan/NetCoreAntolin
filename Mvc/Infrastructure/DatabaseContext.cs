using System.IO;
using Entities.Data;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectMilestoneEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectMilestoneEntityConfiguration());
        }

        public DbSet<Entities.Data.Project> Projects { get; set; }

        public DbSet<Entities.Data.Client> Clients { get; set; }

        public DbSet<Entities.Data.Milestone> Milestones { get; set; }
    }

}
