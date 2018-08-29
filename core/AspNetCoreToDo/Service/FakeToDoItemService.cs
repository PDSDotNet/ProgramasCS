using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Service
{

    public class FakeToDoItemService: IToDoItemService
    {
        public Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new ToDoItem
            {
                Title = "Learn ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };

        var item2 = new ToDoItem
            {
                Title = "Build awesome apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            return Task.FromResult(new[] { item1, item2 });   
        }
    }
}