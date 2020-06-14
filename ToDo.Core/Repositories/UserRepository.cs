using System;
using System.Collections.Generic;
using System.Linq;
using ToDoCore.DbContexts;
using ToDoCore.Entities;

namespace ToDoCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoContext _context;

        public UserRepository(ToDoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        public bool UserExists(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users
                .Any(u => u.Id == userId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
