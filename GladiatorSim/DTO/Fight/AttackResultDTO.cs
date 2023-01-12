using Microsoft.AspNetCore.Mvc;

namespace GladiatorSim.DTO.Fight
{
    public class AttackResultDTO 
    {
        public string Attacker { get; set; }
        public string Oppenent { get; set; }
        public int AttackerHP { get; set; }
        public int OppenentHP { get; set; }
        public int Damage { get; set; }
    }
}
