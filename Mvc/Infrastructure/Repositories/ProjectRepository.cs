using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Data;
using Entities.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseContext _context;

        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .ToListAsync();
            return projects;
        }

        public async Task<IEnumerable<Project>> GetAllWithDataAsync()
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.ProjectMilestones)
                    .ThenInclude(m => m.Milestone)
                .ToListAsync();
            return projects;
        }

        public async Task<IEnumerable<Project>> GetAllByClientAsync(int clientId)
        {
            var projects = await _context.Projects
                .Where(p => p.ClientId == clientId)
                .ToListAsync();
            return projects;
        }

        public async Task Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
    }
}
