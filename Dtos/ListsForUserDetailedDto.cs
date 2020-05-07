using System.Collections.Generic;

namespace ToDo.API.Dtos
{
    public class ListsForUserDetailedDto
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public int itemCount { get; set; }
    }
}