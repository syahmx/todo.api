using System;

namespace ToDo.API.Dtos
{
    public class ItemForDetailedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? RemindAt { get; set; }
    }
}