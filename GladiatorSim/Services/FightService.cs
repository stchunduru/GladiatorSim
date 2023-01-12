using AutoMapper;
using GladiatorSim.Data;
using GladiatorSim.DTO.Fight;
using GladiatorSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace GladiatorSim.Services
{
    public class FightService : IFightService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FightService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<HighScoreDTO>>> GetHighScores()
        {
            var gladiators = await _context.Gladiators
                .Where(c => c.Fights > 0)
                .OrderByDescending(c => c.Victories)
                .ThenBy(c => c.Defeats)
                .ToListAsync();

            var response = new ServiceResponse<List<HighScoreDTO>>
            {
                Data = gladiators.Select(c => _mapper.Map<HighScoreDTO>(c)).ToList()
            };

            return response;
        }

        public async Task<ServiceResponse<FightResultDTO>> Fight(FightRequestDTO request)
        {
            var response = new ServiceResponse<FightResultDTO>
            {
                Data = new FightResultDTO()
            };

            try
            {
                var gladiators = await _context.Gladiators
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .Where(c => request.GladiatorIDs.Contains(c.Id)).ToListAsync();

                bool defeated = false;
                while (!defeated)
                {
                    foreach(Gladiator attacker in gladiators)
                    {
                        var opponents = gladiators.Where(c => c.Id != attacker.Id).ToList();
                        var opponent = opponents[new Random().Next(opponents.Count)];

                        int damage = 0;
                        string attackUsed = string.Empty;

                        bool useWeapon = new Random().Next(2) == 0;
                        if (useWeapon)
                        {
                            attackUsed = attacker.Weapon.Name;
                            damage = DoWeaponAttack(attacker, opponent);
                        } 
                        else
                        {
                            var skill = attacker.Skills[new Random().Next(attacker.Skills.Count)];
                            attackUsed = skill.Name;
                            damage = DoSkillAttack(attacker, opponent, skill);
                        }

                        response.Data.Log
                            .Add($"{attacker.Name} attacked {opponent.Name} using {attackUsed} for {damage} damage!");

                        if(opponent.Health <= 0)
                        {
                            defeated = true;
                            attacker.Victories++;
                            opponent.Defeats++;
                            response.Data.Log.Add($"{opponent.Name} has been defeated!");
                            response.Data.Log.Add($"{attacker.Name} wins with {attacker.Health} HP left!");
                            break;
                        }
                    }
                }

                gladiators.ForEach(c =>
                {
                    c.Fights++;
                    c.Health = 100;
                });

                await _context.SaveChangesAsync();

            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<AttackResultDTO>> SkillAttack(SkillAttackDTO request)
        {
            var response = new ServiceResponse<AttackResultDTO>();
            try
            {
                var attacker = await _context.Gladiators
                    .Include(g => g.Skills)
                    .FirstOrDefaultAsync(g => g.Id == request.AttackerID);
                var opponent = await _context.Gladiators
                    .Include(g => g.Skills)
                    .FirstOrDefaultAsync(g => g.Id == request.OpponentID);

                var skill = attacker.Skills.FirstOrDefault(s => s.Id == request.SkillID);
                if (skill == null)
                {
                    response.Success = false;
                    response.Message = $"{attacker.Name} doesn't know that skill.";
                    return response;
                }

                int damage = DoSkillAttack(attacker, opponent, skill);

                if (opponent.Health <= 0)
                {
                    response.Message = $"{opponent.Name} has been defeated!";
                }

                await _context.SaveChangesAsync();

                response.Data = new AttackResultDTO
                {
                    Attacker = attacker.Name,
                    Oppenent = opponent.Name,
                    AttackerHP = attacker.Health,
                    OppenentHP = opponent.Health,
                    Damage = damage
                };
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }

        private static int DoSkillAttack(Gladiator attacker, Gladiator opponent, Skill skill)
        {
            int damage = skill.Damage + attacker.Strength * 2;
            damage -= opponent.Defense * 2 + opponent.Dexterity;

            if (damage > 0)
            {
                opponent.Health -= damage;
            }

            return damage;
        }

        public async Task<ServiceResponse<AttackResultDTO>> WeaponAttack(WeaponAttackDTO request)
        {
            var response = new ServiceResponse<AttackResultDTO>();
            try
            {
                var attacker = await _context.Gladiators
                    .Include(g => g.Weapon)
                    .FirstOrDefaultAsync(g => g.Id == request.AttackerID);
                var opponent = await _context.Gladiators
                    .Include(g => g.Weapon)
                    .FirstOrDefaultAsync(g => g.Id == request.OppenentID);
                int damage = DoWeaponAttack(/*response, */attacker, opponent);

                if (opponent.Health <= 0)
                {
                    response.Message = $"{opponent.Name} has been defeated!";
                }

                await _context.SaveChangesAsync();

                response.Data = new AttackResultDTO
                {
                    Attacker = attacker.Name,
                    Oppenent = opponent.Name,
                    AttackerHP = attacker.Health,
                    OppenentHP = opponent.Health,
                    Damage = damage
                };
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }

        private static int DoWeaponAttack(Gladiator attacker, Gladiator opponent)
        {
            int damage = attacker.Weapon.Damage + attacker.Strength * 2;
            damage -= opponent.Defense * 2 + opponent.Dexterity;

            if (damage > 0)
            {
                opponent.Health -= damage;
                //response.Message = $"{opponent.Name} was struck and has ${opponent.Health} left!";
            }

            return damage;
        }
    }
}
