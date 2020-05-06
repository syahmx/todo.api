using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;
        public ToDoRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Item> GetItem(int itemId)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public async Task<List> GetList(int listId)
        {
            return await _context.Lists.FirstOrDefaultAsync(l => l.Id == listId);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Include(p => p.Lists).ThenInclude(q => q.Items).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}