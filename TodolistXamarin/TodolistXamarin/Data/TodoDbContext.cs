using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace TodolistXamarin.Data
{
    public class TodoDbContext : iTodo
    {
        readonly SQLiteAsyncConnection _database;

        public TodoDbContext()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todo.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Todo>().Wait();

        }

    

        public async Task AddTodo(Todo todo)
        {
            try
            {
                await _database.InsertAsync(todo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<List<Todo>> GetTodo()
        {
            try
            {
                var todoItems = await _database.Table<Todo>().ToListAsync();
                return todoItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Task<int> DeleteTodoItemAsync(Todo item)
        {
            return _database.DeleteAsync(item);
        }
    
}
}
