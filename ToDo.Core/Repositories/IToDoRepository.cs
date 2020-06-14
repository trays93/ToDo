using System;
using System.Collections.Generic;
using ToDoCore.Entities;

namespace ToDoCore.Repositories
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetToDos(Guid userId);
        ToDo GetToDo(Guid userId, Guid toDoId);
        void AddToDo(Guid userId, ToDo toDo);
        void UpdateToDo(ToDo toDo);
        void DeleteToDo(ToDo toDo);
        bool Save();
    }
}
