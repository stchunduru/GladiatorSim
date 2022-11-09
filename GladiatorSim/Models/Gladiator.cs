using GladiatorSim.Models;
using System.ComponentModel;

namespace GladiatorSim.Models
{
    public class Gladiator
    {
        public int Id { get; set; }
        [DefaultValue("Noman")]
        public string Name { get; set; }
        [DefaultValue(100)]
        public int Health { get; set; }
        [DefaultValue(1)]
        public int Stamina { get; set; }
        [DefaultValue(1)]
        public int Strength { get; set; }
        [DefaultValue(1)]
        public int Defense { get; set; }
        [DefaultValue(1)]
        public int Dexterity { get; set; }

        public GladiatorOrigin Origin { get; set; }
        public GladiatorHistory History { get; set; }
        public GladiatorSponsor Sponsor { get; set; }
        public User? User { get; set; }

    }
}
