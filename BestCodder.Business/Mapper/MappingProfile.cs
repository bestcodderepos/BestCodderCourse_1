using AutoMapper;
using BestCodder.DataAccess.Data;
using BestCodder.Models;

namespace BestCodder.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
        }
    }
}
