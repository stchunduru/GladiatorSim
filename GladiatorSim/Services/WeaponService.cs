using AutoMapper;
using GladiatorSim.Data;
using GladiatorSim.DTO.Gladiator;
using GladiatorSim.DTO.Weapon;
using GladiatorSim.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GladiatorSim.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _http;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IHttpContextAccessor http, IMapper mapper)
        {
            _context = context;
            _http = http;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetGladiatorDTO>> AddWeapon(AddWeaponDTO newWeapon)
        {
            ServiceResponse<GetGladiatorDTO> response = new ServiceResponse<GetGladiatorDTO>();

            try
            {
                Gladiator g = await _context.Gladiators
                .FirstOrDefaultAsync(c => c.Id == newWeapon.GladiatorId &&
                c.User.Id == int.Parse(_http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if(g == null)
                {
                    response.Success = false;
                    response.Message = "Not found";
                    return response;
                }

                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Gladiator = g
                };

                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetGladiatorDTO>(g);

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
