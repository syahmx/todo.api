using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Data;

namespace ToDo.API.Controllers
{
    [Route("")]
    [ApiController]
    public class ShortURLController : ControllerBase
    {
        private readonly IToDoRepository _repo;
        private readonly IMapper _mapper;
        public ShortURLController(IToDoRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{listUniqueId}")]
        public async Task<IActionResult> GetUser(string listUniqueId)
        {
            var list = await _repo.GetListByUniqueId(listUniqueId);
            var listUserId = list.UserId;

            return Redirect("http://localhost:4200/api/users/" + listUserId + "/lists/" + list.Id);
        }
    }
}