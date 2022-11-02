using GladiatorSim.Models;
using Microsoft.EntityFrameworkCore;

namespace GladiatorSim.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Gladiator> Gladiators => Set<Gladiator>();

    }
}
