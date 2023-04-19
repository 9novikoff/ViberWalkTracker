using Microsoft.EntityFrameworkCore;
using ViberWalkTracker.DAL.DALModels;

namespace ViberWalkTracker.DAL
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<UserDAL> Users { get; set; }
    }
}
