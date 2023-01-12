using GladiatorSim.DTO.Fight;
using GladiatorSim.Models;
using GladiatorSim.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace GladiatorSim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : Controller
    {
        private readonly IFightService _service;
        public FightController(IFightService service)
        {
            _service = service;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDTO>>> WeaponAttack(WeaponAttackDTO request)
        {
            return Ok(await _service.WeaponAttack(request));
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDTO>>> SkillAttack(SkillAttackDTO request)
        {
            return Ok(await _service.SkillAttack(request));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FightResultDTO>>> Fight(FightRequestDTO request)
        {
            return Ok(await _service.Fight(request));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<HighScoreDTO>>>> GetHighScores()
        {
            return Ok(await GetHighScores());
        }
                           
    }
}
