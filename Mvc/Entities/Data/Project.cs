using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Data
{
    public class Project
    {
        public Project()
        {
            ProjectMilestones = new List<ProjectMilestone>();
        }
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<ProjectMilestone> ProjectMilestones { get; set; }
    }
}
