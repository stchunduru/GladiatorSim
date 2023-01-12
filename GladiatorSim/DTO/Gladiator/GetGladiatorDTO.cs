using GladiatorSim.DTO.Skill;
using GladiatorSim.DTO.Weapon;
using GladiatorSim.Models;

namespace GladiatorSim.DTO.Gladiator
{
    public class GetGladiatorDTO
    {
        public string Name { get; set; } 
        public int Health { get; set; } 
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; } 
        public int Dexterity { get; set; }

        public GladiatorOrigin Origin { get; set; }
        public GladiatorHistory History { get; set; }
        public GladiatorSponsor Sponsor { get; set; }
        public GetWeaponDTO Weapon { get; set; }
        public List<GetSkillDTO> Skills { get; set; }
    }
}
