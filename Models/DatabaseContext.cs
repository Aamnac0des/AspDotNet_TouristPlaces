using Microsoft.EntityFrameworkCore;
using static Aamnaa_proj.Models.Place;

namespace Aamnaa_proj.Models

{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }
    }
}
