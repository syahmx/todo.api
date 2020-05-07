using System;
using System.Collections.Generic;
using ToDo.API.Models;

namespace ToDo.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public ICollection<ListsForUserDetailedDto> Lists { get; set; }
    }
}