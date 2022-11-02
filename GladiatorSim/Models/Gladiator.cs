using GladiatorSim.Models;

namespace GladiatorSim.Models
{
    public class Gladiator
    {
        public int Id { get; set; }
        public string Name { get; set; } = "NoMan";
        public int Health { get; set; } = 100;
        public int Stamina { get; set; } = 1;
        public int Strength { get; set; } = 1;
        public int Defense { get; set; } = 1;
        public int Dexterity { get; set; } = 1;
        
        public GladiatorOrigin Origin { get; set; }
        public GladiatorHistory History { get; set; }
        public GladiatorSponsor Sponsor { get; set; }


    }
}
