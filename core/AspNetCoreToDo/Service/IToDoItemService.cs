using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;


namespace AspNetCoreToDo.Service
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemsAsync( ApplicationUser user);
        //Task<ToDoItem[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(ToDoItem newItem, ApplicationUser user);

        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}