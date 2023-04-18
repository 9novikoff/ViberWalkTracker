using AutoMapper;
using ViberWalkTracker.DAL.DALModels;
using ViberWalkTracker.ModelsDTO;

namespace ViberWalkTracker
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WalkDAL, WalkDTO>();
        }
    }
}
