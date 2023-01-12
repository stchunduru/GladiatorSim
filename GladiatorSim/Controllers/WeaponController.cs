using GladiatorSim.DTO.Gladiator;
using GladiatorSim.DTO.Weapon;
using GladiatorSim.Models;
using GladiatorSim.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GladiatorSim.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _service;
        public WeaponController(IWeaponService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetGladiatorDTO>>> AddWeapon(AddWeaponDTO newWeapon)
        {
            return Ok(await _service.AddWeapon(newWeapon));
        }
    }
}
