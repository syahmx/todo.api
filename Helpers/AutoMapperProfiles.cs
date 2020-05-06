using AutoMapper;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>();
            CreateMap<List, ListForDetailedDto>();
            CreateMap<Item, ItemForDetailedDto>();
        }
    }
}