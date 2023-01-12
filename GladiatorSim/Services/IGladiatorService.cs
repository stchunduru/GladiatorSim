using GladiatorSim.DTO.Gladiator;
using GladiatorSim.Models;

namespace GladiatorSim.Services
{
    public interface IGladiatorService
    {
        Task<ServiceResponse<List<GetGladiatorDTO>>> GetAllGladiators();
        Task<ServiceResponse<GetGladiatorDTO>> GetGladiator(int id);
        Task<ServiceResponse<List<GetGladiatorDTO>>> CreateGladiator(AddGladiatorDTO newGladiator);
        Task<ServiceResponse<GetGladiatorDTO>> Update(UpdateGladiatorDTO updateGladiator);
        Task<ServiceResponse<List<GetGladiatorDTO>>> DeleteGladiator(int id);
        Task<ServiceResponse<GetGladiatorDTO>> AddGladiatorSkill(AddGladiatorSkillDTO skill);
    }
}
