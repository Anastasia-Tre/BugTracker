using AutoMapper;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataModel;

namespace BugTracker.Services.Mapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug<int>, BugEntity<int>>().ReverseMap();
            CreateMap<User<int>, UserEntity<int>>().ReverseMap();
            CreateMap<Project<int>, ProjectEntity<int>>().ReverseMap();
        }
    }
}
