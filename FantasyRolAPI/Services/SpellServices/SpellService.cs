using AutoMapper;
using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs.SepllDTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.SpellServices
{
    public class SpellService : ISpellService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SpellService(IConfiguration configuration, AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _db = dbContext;
            _configuration = configuration;
        }

        

        public async Task AddSpellCharacter(Guid characterId, Guid spellId)
        {
            var characterSpell = new CharacterSpell
            {
                CharacterId = characterId,
                SpellId = spellId
            };
            await _db.AddAsync(characterSpell);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteSpellCharacter(Guid characterId, Guid spellId)
        {
            var asDb = await _db.CharacterSpell.Where(s=>s.SpellId== spellId&& s.CharacterId==characterId).FirstOrDefaultAsync();
            if(asDb != null)
                _db.CharacterSpell.Remove(asDb);
            await _db.SaveChangesAsync();
        }
        public async Task<object> GetSpells(
            int pageSize = 10,
            int currentPage = 1,
            string filter = "",
            string level = "",
            string school = "",
            string description = "")
        {
            var query = _mapper.ProjectTo<SpellMiniDTO>(_db.Spell);
            query = query.Where(s =>
                (string.IsNullOrEmpty(filter) || s.Name.Contains(filter))
                && (string.IsNullOrEmpty(description) || s.Description.Contains(description))
                && (string.IsNullOrEmpty(level) || level.Contains(s.SpellLevel.ToString()))
                
                ).OrderBy(d => d.SpellLevel);

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var paginatedQuery = query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);

            var results = await paginatedQuery.ToListAsync();

            return new
            {
                TotalCount = totalCount,
                Results = results
            };
        }
        public async Task<object> GetSpellsCharacter(
            Guid characterId,
            int pageSize = 10,
            int currentPage = 1,
            string filter = "",
            string level = "",
            string school = "",
            string description = "")
        {
            var query = _mapper.ProjectTo<SpellMiniDTO>(_db.CharacterSpell.Where(c=>c.CharacterId==characterId).Select(c=>c.Spell));
            query = query.Where(s =>
                (string.IsNullOrEmpty(filter) || s.Name.Contains(filter))
                && (string.IsNullOrEmpty(description) || s.Description.Contains(description))
                && (string.IsNullOrEmpty(level) || level.Contains(s.SpellLevel.ToString()))
                
                ).OrderBy(d => d.SpellLevel);

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var paginatedQuery = query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);

            var results = await paginatedQuery.ToListAsync();

            return new
            {
                TotalCount = totalCount,
                Results = results
            };
        }


    }
}
