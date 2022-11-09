using AutoMapper;
using GladiatorSim.Data;
using GladiatorSim.DTO.Gladiator;
using GladiatorSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace GladiatorSim.Services
{
    public class GladiatorService : IGladiatorService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _http;

        //private static List<Gladiator> _list = new List<Gladiator>();

        public GladiatorService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _http = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_http.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetGladiatorDTO>>> GetAllGladiators()
        {
            var response = new ServiceResponse<List<GetGladiatorDTO>>();
            var glads = await _context.Gladiators.Where(c => c.User.Id == GetUserId()).ToListAsync();
            response.Data = glads.Select(g => _mapper.Map<GetGladiatorDTO>(g)).ToList();
            return response;

            //return new ServiceResponse<List<GetGladiatorDTO>> 
            //{ 
            //    Data = _list.Select(c => _mapper.Map<GetGladiatorDTO>(c)).ToList() 
            //};
        }

        public async Task<ServiceResponse<GetGladiatorDTO>> GetGladiator(int id)
        {
            var response = new ServiceResponse<GetGladiatorDTO>();
            response.Data = _mapper.Map<GetGladiatorDTO>( await _context.Gladiators.FirstOrDefaultAsync(g => g.Id == id));
            return response;

            //var serviceResponse = new ServiceResponse<GetGladiatorDTO>();
            //serviceResponse.Data = _mapper.Map<GetGladiatorDTO>(_list.FirstOrDefault(c => c.Id == id));
            //return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGladiatorDTO>>> CreateGladiator(AddGladiatorDTO newGladiator)
        {
            var response = new ServiceResponse<List<GetGladiatorDTO>>();
            Gladiator g = _mapper.Map<Gladiator>(newGladiator);
            g.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            _context.Add(g);
            await _context.SaveChangesAsync();
            response.Data = await _context.Gladiators
                .Where(c => c.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetGladiatorDTO>(c))
                .ToListAsync();
            return response;


            //var serviceResponse = new ServiceResponse<List<GetGladiatorDTO>>();
            //Gladiator gladiator = _mapper.Map<Gladiator>(newGladiator);

            //gladiator.Id = _list.Count > 0 ? _list.Max(c => c.Id) + 1 : 0;

            //_list.Add(gladiator); 
            //serviceResponse.Data = _list.Select(c => _mapper.Map<GetGladiatorDTO>(c)).ToList();
            //return serviceResponse;
        }

        public async Task<ServiceResponse<GetGladiatorDTO>> Update(UpdateGladiatorDTO updateGladiator)
        {
            ServiceResponse<GetGladiatorDTO> response = new ServiceResponse<GetGladiatorDTO>();

            try
            {
                var g = await _context.Gladiators.FirstOrDefaultAsync(c => c.Id == updateGladiator.Id);
                g.Health = updateGladiator.Health;
                g.Strength = updateGladiator.Strength;
                g.Name = updateGladiator.Name;
                g.Stamina = updateGladiator.Stamina;
                g.Dexterity = updateGladiator.Dexterity;
                g.Defense = updateGladiator.Defense;
                g.History = updateGladiator.History;
                g.Origin = updateGladiator.Origin;
                g.Sponsor = updateGladiator.Sponsor;
                
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetGladiatorDTO>(g);

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            //try
            //{
            //    Gladiator g = _list.FirstOrDefault(c => c.Id == updateGladiator.Id);
            //    _mapper.Map(updateGladiator, g);
            //    response.Data = _mapper.Map<GetGladiatorDTO>(g);

            //    //if (g != null)
            //    //{
            //    //    int index = _list.FindIndex(c => c == g);
            //    //    _list[index] = _mapper.Map<Gladiator>(updateGladiator);
            //    //}
            //}
            //catch (Exception e)
            //{
            //    response.Success = false;
            //    response.Message = e.Message;
            //}

            return response;
        }

        public async Task<ServiceResponse<List<GetGladiatorDTO>>> DeleteGladiator(int id)
        {
            var response = new ServiceResponse<List<GetGladiatorDTO>>();

            try
            {
                Gladiator g = await _context.Gladiators.FirstOrDefaultAsync(c => c.Id == id);
                _context.Gladiators.Remove(g);
                await _context.SaveChangesAsync();

                response.Data = await _context.Gladiators
                .Select(g => _mapper.Map<GetGladiatorDTO>(g))
                .ToListAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }


            //var serviceResponse = new ServiceResponse<List<GetGladiatorDTO>>();
            //try
            //{
            //    Gladiator g = _list.FirstOrDefault(g => g.Id == id);
            //    _list.Remove(g);
            //    serviceResponse.Data = _list.Select(c => _mapper.Map<GetGladiatorDTO>(c)).ToList();
            //}
            //catch(Exception e)
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = e.Message;
            //}

            return response;
        }

    }
}
