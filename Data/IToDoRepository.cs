using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public interface IToDoRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<User> GetUser(int id);
        Task<List> GetList(int listId);
        Task<Item> GetItem(int itemId);
        Task<List> GetListByUniqueId(string listUniqueId);
    }
}