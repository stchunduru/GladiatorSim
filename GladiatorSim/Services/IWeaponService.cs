using GladiatorSim.DTO.Gladiator;
using GladiatorSim.DTO.Weapon;
using GladiatorSim.Models;

namespace GladiatorSim.Services
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetGladiatorDTO>> AddWeapon(AddWeaponDTO newWeapon);
    }
}
