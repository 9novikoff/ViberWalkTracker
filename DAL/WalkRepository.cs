using Microsoft.EntityFrameworkCore;
using ViberWalkTracker.DAL.DALModels;
using System.Linq;

namespace ViberWalkTracker.DAL
{
    public class WalkRepository
    {
        private WalkContext _walkContext;
        public WalkRepository(WalkContext walkContext) {
            _walkContext = walkContext;
        }

        public async Task<List<WalkDAL>> GetAllWalks()
        {
            return await _walkContext.Walks.ToListAsync();
        }
    }
}
