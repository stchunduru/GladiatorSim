using AutoMapper;
using GladiatorSim.DTO.Gladiator;
using GladiatorSim.Models;

namespace GladiatorSim.Mapping
{
    public class GladiatorMapping : Profile 
    {
        public GladiatorMapping()
        {
            CreateMap<Gladiator, GetGladiatorDTO>();
            CreateMap<GetGladiatorDTO, Gladiator>();
            CreateMap<Gladiator, AddGladiatorDTO>();
            CreateMap<AddGladiatorDTO, Gladiator>();
            CreateMap<Gladiator, UpdateGladiatorDTO>();
            CreateMap<UpdateGladiatorDTO, Gladiator>();
            CreateMap<UpdateGladiatorDTO, GetGladiatorDTO>();

        }
    }
}
