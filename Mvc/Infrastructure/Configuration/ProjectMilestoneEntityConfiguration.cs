using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProjectMilestoneEntityConfiguration : IEntityTypeConfiguration<ProjectMilestone>
    {
        public void Configure(EntityTypeBuilder<ProjectMilestone> builder)
        {
            builder.HasKey(p => new { p.ProjectId , p.MilestoneId});

            builder.HasOne(p => p.Project)
                .WithMany(p => p.ProjectMilestones)
                .HasForeignKey(p => p.ProjectId);

            builder.HasOne(p => p.Milestone)
                .WithMany()
                .HasForeignKey(p => p.MilestoneId);

            builder.Property(p => p.ExpectedDate);

        }
    }
}