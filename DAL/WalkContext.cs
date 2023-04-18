using Microsoft.EntityFrameworkCore;
using ViberWalkTracker.DAL.DALModels;

namespace ViberWalkTracker.DAL
{
    public class WalkContext : DbContext
    {
        public WalkContext(DbContextOptions<WalkContext> options) : base(options)
        {
        }
        public DbSet<WalkDAL> Walks { get; set; }
    }
}
