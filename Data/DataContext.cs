using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}