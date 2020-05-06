using System.Collections.Generic;

namespace ToDo.API.Models
{
    public class List
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}