using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using AspNetCoreToDo.Service;
using AspNetCoreToDo.Models;


namespace AspNetCoreToDo.Controllers
{
    [Authorize] 
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


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(ToDoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            
            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }


    }
}