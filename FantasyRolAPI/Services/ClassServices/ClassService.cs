using AutoMapper;
using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.ClassServices
{
    public class ClassService : IClassService
    {

        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ClassService(IConfiguration configuration, AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _db = dbContext;
            _configuration = configuration;
        }

        public async Task<ClassMiniDTO> getClassById(Guid classId)
        {
            var asDb =await _db.Class.Where(c=>c.Id == classId).FirstOrDefaultAsync();
            var result = _mapper.Map<ClassMiniDTO>(asDb);

            return result;

        }
    }
}
