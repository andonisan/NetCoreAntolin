using AutoMapper;
using Entities.Data;
using WebAPi.ViewModel.Project;

namespace WebAPi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProjectDto, Project>()
                .ReverseMap();
            CreateMap<Project, ProjectWithDataDto>();
            CreateMap<ProjectCreateDto, Project>();
        }
    }
}