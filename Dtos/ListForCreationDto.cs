using System;

namespace ToDo.API.Dtos
{
    public class ListForCreationDto
    {
        public string ListName { get; set; }
        public DateTime Created { get; set; }
    }
}