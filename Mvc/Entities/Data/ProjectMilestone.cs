using System;

namespace Entities.Data
{
    public class ProjectMilestone
    {
        public int ProjectId { get; set; }

        public int MilestoneId { get; set; }

        public Project Project { get; set; }

        public Milestone Milestone { get; set; }

        public DateTime ExpectedDate { get; set; }

        public DateTime RealDate { get; set; }
    }
}