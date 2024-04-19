using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodolistXamarin.Data;

namespace TodolistXamarin
{
    public interface iTodo
    {
        Task AddTodo (Todo todo);
        Task<List<Todo>> GetTodo();

    }
}
