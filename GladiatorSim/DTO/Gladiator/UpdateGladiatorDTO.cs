using GladiatorSim.Models;

namespace GladiatorSim.DTO.Gladiator
{
    public class UpdateGladiatorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Health { get; set; } 
        public int Stamina { get; set; } 
        public int Strength { get; set; } 
        public int Defense { get; set; } 
        public int Dexterity { get; set; }

        public GladiatorOrigin Origin { get; set; }
        public GladiatorHistory History { get; set; }
        public GladiatorSponsor Sponsor { get; set; }
    }
}
