using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.API.Models
{
    public class List
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string ListName { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}