using Microsoft.EntityFrameworkCore;

namespace RockStars.Persistance.Db
{
    public class CleanArchWriteDbContext : AppDbContext
    {
        public CleanArchWriteDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}