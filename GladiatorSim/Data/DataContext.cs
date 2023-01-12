using GladiatorSim.Models;
using Microsoft.EntityFrameworkCore;

namespace GladiatorSim.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Light Attack", Damage = 30 },
                new Skill { Id = 2, Name = "Heavy Attack", Damage = 60 },
                new Skill { Id = 3, Name = "Ultra Attack", Damage = 90 }
                );
        }

        public DbSet<Gladiator> Gladiators => Set<Gladiator>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        public DbSet<Skill> Skills => Set<Skill>();



    }
}
