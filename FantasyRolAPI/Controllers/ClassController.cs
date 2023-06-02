using AutoMapper;
using FantasyRolAPI.Services.ClassServices;
using FantasyRolAPI.Services.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IClassService _classService;

        public ClassController(IConfiguration configuration, IMapper mapper, IClassService classService) : base(mapper)
        {
            _configuration = configuration;
            _classService = classService;
        }


        [HttpPost("GetClassById")]
        public async Task<IActionResult> GetClassById(Guid Id)
        {
            try
            {

                var result = await _classService.getClassById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
