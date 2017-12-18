using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Data;

namespace Infrastructure.Initializers
{
    public static class Initiaizer
    {
        public static void EnsureSeeded(this DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Projects.Any())
            {

                var milestonePhaseClosure = new Milestone()
                {
                    MilestoneType = MilestoneType.PhaseClosure,
                    Name = "Fecha SOP"
                };

                var milestoneKpi = new Milestone()
                {
                    MilestoneType = MilestoneType.Kpi,
                    Name = "Fecha EOP"
                };

                context.Milestones.Add(milestonePhaseClosure);
                context.Milestones.Add(milestoneKpi);

                var client = new Client()
                {
                    Code = "VW",
                    Name = "Volkswagen"
                };

                context.Clients.Add(client);

                var projectWEbApi = new Project()
                {
                    Code = "17321T41",
                    Name = "Techo polo A04",
                    Alias = "Polo Classic",
                    ClientId = client.Id,
                    Client = client
                };

                var projectMvc = new Project()
                {
                    Code = "16201P31",
                    Name = "Puerta Seat S14",
                    Alias = "Seat Ibiza",
                    ClientId = client.Id,
                    Client = client
                };

                projectWEbApi.ProjectMilestones.Add(new ProjectMilestone()
                {
                    Project = projectWEbApi,
                    ProjectId = projectWEbApi.Id,
                    ExpectedDate = DateTime.Today.AddDays(5),
                    Milestone = milestonePhaseClosure,
                    MilestoneId = milestoneKpi.Id,
                });

                projectMvc.ProjectMilestones.Add(new ProjectMilestone()
                {
                    Project = projectMvc,
                    ProjectId = projectMvc.Id,
                    ExpectedDate = DateTime.Today.AddDays(30),
                    Milestone = milestoneKpi,
                    MilestoneId = milestoneKpi.Id,
                });

                context.Projects.Add(projectWEbApi);
                context.Projects.Add(projectMvc);
                context.SaveChanges();
            }
        }
    }
}
