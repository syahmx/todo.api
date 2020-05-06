using System;

namespace ToDo.API.Dtos
{
    public class ItemForDetailedDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime RemindAt { get; set; }
    }
}