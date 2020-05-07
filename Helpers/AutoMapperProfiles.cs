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
            CreateMap<List, ListsForUserDetailedDto>()
                .ForMember(x => x.itemCount, opt => opt.MapFrom(x => x.Items.Count));
            CreateMap<UserForAvailability, User>();
            CreateMap<List, ListForDetailedDto>();
            CreateMap<ListForCreationDto, List>();
            CreateMap<ListForUpdateDto, List>();
            CreateMap<Item, ItemForDetailedDto>();
            CreateMap<ItemForCreationDto, Item>();
            CreateMap<ItemForUpdateDto, Item>();
        }
    }
}