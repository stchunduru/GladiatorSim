using System.Reflection.PortableExecutable;

namespace GladiatorSim.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Gladiator Gladiator { get; set; }
        public int GladiatorId { get; set; }
    }
}
