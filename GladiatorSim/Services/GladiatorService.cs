using AutoMapper;
using GladiatorSim.DTO.Gladiator;
using GladiatorSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace GladiatorSim.Services
{
    public class GladiatorService : IGladiatorService
    {
        private readonly IMapper _mapper;
        private static List<Gladiator> _list = new List<Gladiator>();

        public GladiatorService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetGladiatorDTO>>> GetAllGladiators()
        {
            return new ServiceResponse<List<GetGladiatorDTO>> { Data = _list.Select(c => _mapper.Map<GetGladiatorDTO>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetGladiatorDTO>> GetGladiator(int id)
        {
            var serviceResponse = new ServiceResponse<GetGladiatorDTO>();
            serviceResponse.Data = _mapper.Map<GetGladiatorDTO>(_list.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGladiatorDTO>>> CreateGladiator(AddGladiatorDTO newGladiator)
        {
            var serviceResponse = new ServiceResponse<List<GetGladiatorDTO>>();
            Gladiator gladiator = _mapper.Map<Gladiator>(newGladiator);

            gladiator.Id = _list.Count > 0 ? _list.Max(c => c.Id) + 1 : 0;

            _list.Add(gladiator); 
            serviceResponse.Data = _list.Select(c => _mapper.Map<GetGladiatorDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGladiatorDTO>> Update(UpdateGladiatorDTO updateGladiator)
        {
            ServiceResponse<GetGladiatorDTO> response = new ServiceResponse<GetGladiatorDTO>();

            try
            {
                Gladiator g = _list.FirstOrDefault(c => c.Id == updateGladiator.Id);
                _mapper.Map(updateGladiator, g);
                response.Data = _mapper.Map<GetGladiatorDTO>(g);

                //if (g != null)
                //{
                //    int index = _list.FindIndex(c => c == g);
                //    _list[index] = _mapper.Map<Gladiator>(updateGladiator);
                //}
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetGladiatorDTO>>> DeleteGladiator(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGladiatorDTO>>();
            try
            {
                Gladiator g = _list.FirstOrDefault(g => g.Id == id);
                _list.Remove(g);
                serviceResponse.Data = _list.Select(c => _mapper.Map<GetGladiatorDTO>(c)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

    }
}
