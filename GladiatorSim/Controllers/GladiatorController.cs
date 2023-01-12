using GladiatorSim.DTO.Gladiator;
using GladiatorSim.Models;
using GladiatorSim.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GladiatorSim.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GladiatorController : ControllerBase
    {
        private static List<Gladiator> _list = new List<Gladiator>();
        IGladiatorService _gladiatorService;

        public GladiatorController(IGladiatorService gladiatorService)
        {
            _gladiatorService = gladiatorService;
        }

        // GET: api/<ValuesController>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Gladiator>>>> GetAll()
        {
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _gladiatorService.GetAllGladiators());
        }

        [HttpGet("Get{id}")]
        public async Task<ActionResult<ServiceResponse<Gladiator>>> Get(int id)
        {
            return Ok(await _gladiatorService.GetGladiator(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ServiceResponse<List<GetGladiatorDTO>>>> Create(AddGladiatorDTO gladiator)
        {
            return Ok(await _gladiatorService.CreateGladiator(gladiator));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<GetGladiatorDTO>>> Update(UpdateGladiatorDTO gladiator)
        {
            var response = await _gladiatorService.Update(gladiator);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult<ServiceResponse<List<Gladiator>>>> Delete(int id)
        {
            return Ok(await _gladiatorService.DeleteGladiator(id));
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetGladiatorDTO>>> AddGladiatorSkill(AddGladiatorSkillDTO skill)
        {
            return Ok(await _gladiatorService.AddGladiatorSkill(skill));
        }

    }
}
