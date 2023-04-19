using AutoMapper;
using ViberWalkTracker.DAL.DALModels;
using ViberWalkTracker.ModelsDTO;

namespace ViberWalkTracker
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WalkDAL, WalkDTO>().ForMember(to => to.Duration, cf => cf.MapFrom(src => (src.End_time - src.Start_time).Minutes));
        }
    }
}
