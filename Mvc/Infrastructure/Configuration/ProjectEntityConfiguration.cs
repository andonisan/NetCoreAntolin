using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Alias)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasOne(p => p.Client)
                .WithMany();

            builder.HasMany(p => p.ProjectMilestones)
                .WithOne(m => m.Project);
        }
    }
}