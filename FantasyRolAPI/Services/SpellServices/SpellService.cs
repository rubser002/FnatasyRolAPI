using AutoMapper;
using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs.SepllDTOs;
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

        public async Task<object> GetSpells(
            int pageSize=10, 
            int currentPage=1, 
            string filter = null, 
            string level = null, 
            string school = null,
            string description = null)
        {
            var query = _mapper.ProjectTo<SpellMiniDTO>(_db.Spell)
            .Where(s =>
                filter.Contains(s.Name)
                && description.Contains(s.Description)
                && level.Contains(s.SpellLevel.ToString())
                && school.Contains(s.SchoolDesc))
            .OrderBy(s => s.SpellLevel);

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
