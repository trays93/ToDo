using System;
using System.Collections.Generic;
using ToDoCore.Entities;

namespace ToDoCore.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool UserExists(Guid userId);
        bool Save();
    }
}
