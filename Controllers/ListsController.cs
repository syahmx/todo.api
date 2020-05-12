using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Data;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Authorize]
    [Route("api/users/{id}/lists")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IToDoRepository _repo;
        public ListsController(IToDoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{listId}")]
        public async Task<IActionResult> GetList(int id, int listId)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            if (!userFromRepo.Lists.Any(x => x.Id == listId))
                return Unauthorized();

            var listFromRepo = await _repo.GetList(listId);

            var list = _mapper.Map<ListForDetailedDto>(listFromRepo);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddList(int id, ListForCreationDto listForCreationDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            listForCreationDto.Created = DateTime.Now;
            listForCreationDto.UniqueId = RandomString(5);

            var list = _mapper.Map<List>(listForCreationDto);

            userFromRepo.Lists.Add(list);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Could not add list");
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPut("{listId}")]
        public async Task<IActionResult> UpdateList(int id, int listId, ListForUpdateDto listForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            if (!userFromRepo.Lists.Any(x => x.Id == listId))
                return Unauthorized();

            var listFromRepo = await _repo.GetList(listId);

            _mapper.Map(listForUpdateDto, listFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Updating list failed on save");
        }

        [HttpDelete("{listId}")]
        public async Task<IActionResult> DeleteList(int id, int listId)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            if (!userFromRepo.Lists.Any(l => l.Id == listId))
                return Unauthorized();

            var listFromRepo = await _repo.GetList(listId);

            _repo.Delete(listFromRepo);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the list");
        }
    }
}