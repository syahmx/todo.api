using System.Collections.Generic;

namespace ToDo.API.Dtos
{
    public class ListForDetailedDto
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public ICollection<ItemForDetailedDto> Items { get; set; }
    }
}