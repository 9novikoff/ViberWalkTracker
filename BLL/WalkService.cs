using AutoMapper;
using ViberWalkTracker.DAL;
using ViberWalkTracker.ModelsDTO;

namespace ViberWalkTracker.BLL
{
    public class WalkService
    {
        private WalkRepository _walkRepository;
        private IMapper _mapper;
        public WalkService(WalkRepository repository, IMapper mapper = null)
        {
            _walkRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<WalkDTO>> GetAllWalksByIMEI(string IMEI)
        {
            var walks = await _walkRepository.GetAllWalks();
            return _mapper.Map<List<WalkDTO>>(walks.Where(w => w.IMEI == IMEI));
        }

        public async Task<List<WalkDTO>> GetTop10WalksByIMEI(string IMEI)
        {
            int top = 10;

            var walks = await _walkRepository.GetAllWalks();
            return _mapper.Map<List<WalkDTO>>(walks.OrderByDescending(w => w.Distance).Take(top));
        }
    }
}
