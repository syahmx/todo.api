using System;

namespace ToDo.API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime RemindAt { get; set; }
        public List List { get; set; }
        public int ListId { get; set; }
    }
}