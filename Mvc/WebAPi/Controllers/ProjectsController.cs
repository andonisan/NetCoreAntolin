using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities.Data;
using Entities.Repositories;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Filters;
using WebAPi.ViewModel.Project;

namespace WebAPi.Controllers
{
    [ApiVersion("1", Deprecated = true)]
    [Route("v{version:apiVersion}/Projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper, DatabaseContext context)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> GetProjects()
        {
            var projects = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        // GET: api/Projects
        [HttpGet("with-data")]
        public async Task<IEnumerable<ProjectWithDataDto>> GetProjectsWithData()
        {
            var projects = await _projectRepository.GetAllWithDataAsync();
            return _mapper.Map<IEnumerable<ProjectWithDataDto>>(projects);
        }

        // GET: api/Projects
        [Obsolete]
        [HttpGet("with-data-database")]
        [MapToApiVersion("1"),]
        public IEnumerable<ProjectWithDataDto> GetProjectsWithDataBase()
        {
            return _context.Projects
                 .ProjectTo<ProjectWithDataDto>()
                 .ToList();
        }

        // POST: api/Projects
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> PostProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            var project = _mapper.Map<Project>(projectCreateDto);
            await _projectRepository.Create(project);

            return Ok();
        }
    }
}