using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Data;

namespace WebAPi.ViewModel.Project
{
    public class ProjectWithDataDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string ClientName { get; set; }

        public IEnumerable<ProjectMilestoneDto> ProjectMilestones { get; set; }
    }
}
