using System;
using System.Collections.Generic;
using System.Linq;
using ToDoCore.DbContexts;
using ToDoCore.Entities;

namespace ToDoCore.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<ToDo> GetToDos(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.ToDos
                .Where(t => t.UserId == userId)
                .OrderBy(t => t.CreatedAt)
                .ToList();
        }

        public ToDo GetToDo(Guid userId, Guid toDoId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (toDoId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(toDoId));
            }

            return _context.ToDos
                .Where(t => t.UserId == userId
                        && t.Id == toDoId)
                .FirstOrDefault();
        }

        public void AddToDo(Guid userId, ToDo toDo)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            toDo.UserId = userId;
            _context.ToDos.Add(toDo);
        }

        public void UpdateToDo(ToDo toDo)
        {
            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            _context.ToDos.Update(toDo);
        }

        public void DeleteToDo(ToDo toDo)
        {
            _context.ToDos.Remove(toDo);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
