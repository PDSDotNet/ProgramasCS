using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreToDo.Service;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Controllers
{
    public class ToDoController: Controller
    {
        // Actions go here
        private readonly IToDoItemService _todoItemService;

        public ToDoController(IToDoItemService todoItemService)
        {
            _todoItemService = todoItemService;
           

        }

            
        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompleteItemsAsync();

                var model = new ToDoViewModel()
                {
                    Items = items
                };
                return View(model); 

        }
    }
}