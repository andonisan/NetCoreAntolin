using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Data;

namespace Entities.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();

        Task<IEnumerable<Project>> GetAllWithDataAsync();

        Task<IEnumerable<Project>> GetAllByClientAsync(int clientId);

        Task Create(Project project);
    }
}
