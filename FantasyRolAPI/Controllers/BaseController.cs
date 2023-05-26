using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController( IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
