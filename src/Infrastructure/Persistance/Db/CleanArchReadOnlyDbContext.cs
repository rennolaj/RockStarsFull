using Microsoft.EntityFrameworkCore;

namespace RockStars.Persistance.Db
{
    public class CleanArchReadOnlyDbContext : AppDbContext
    {
        public CleanArchReadOnlyDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
