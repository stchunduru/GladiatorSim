using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace GladiatorSim.DTO.Fight
{
    public class WeaponAttackDTO 
    {
        public int AttackerID { get; set; }
        public int OppenentID { get; set; }
        public int SkillID { get; set; }

    }
}
