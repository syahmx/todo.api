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
    [Route("api/users/{id}/lists/{listId}/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IToDoRepository _repo;
        public ItemsController(IToDoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int id, int listId, ItemForCreationDto itemForCreationDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            if (!userFromRepo.Lists.Any(p => p.Id == listId))
                return Unauthorized();

            var listFromRepo = await _repo.GetList(listId);

            itemForCreationDto.Created = DateTime.Now;

            var item = _mapper.Map<Item>(itemForCreationDto);

            listFromRepo.Items.Add(item);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Could not add list");
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItem(int id, int listId, int itemId, ItemForUpdateDto itemForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            if (!userFromRepo.Lists.Any(l => l.Id == listId))
                return Unauthorized();

            var listFromRepo = await _repo.GetList(listId);

            if (!listFromRepo.Items.Any(i => i.Id == itemId))
                return BadRequest();

            var itemFromRepo = await _repo.GetItem(itemId);

            _mapper.Map(itemForUpdateDto, itemFromRepo);

            if (await _repo.SaveAll())
                return Ok();

            throw new Exception("Updating item failed on save");
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItem(int id, int listId, int itemId)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            if (!userFromRepo.Lists.Any(l => l.Id == listId))
                return Unauthorized();

            var listFromRepo = await _repo.GetList(listId);

            if (!listFromRepo.Items.Any(i => i.Id == itemId))
                return BadRequest();

            var itemFromRepo = await _repo.GetItem(itemId);

            _repo.Delete(itemFromRepo);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the item");
        }
    }
}