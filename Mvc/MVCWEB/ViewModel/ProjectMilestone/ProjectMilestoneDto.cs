using System;
using Entities.Data;

namespace WebAPi.ViewModel.Project
{
    public class ProjectMilestoneDto
    {
        public string MilestoneName { get; set; }

        public DateTime ExpectedDate { get; set; }

        public DateTime RealDate { get; set; }
    }
}