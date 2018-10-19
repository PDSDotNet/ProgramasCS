using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using AspNetCoreToDo.Service;
using AspNetCoreToDo.Models;


namespace AspNetCoreToDo.Controllers
{
    [Authorize] 
    public class ToDoController: Controller
    {
        // Actions go here
        private readonly IToDoItemService _todoItemService;
        private readonly UserManager<ApplicationUser> _userManager;

        //public ToDoController(IToDoItemService todoItemService)
        public ToDoController(IToDoItemService todoItemService, UserManager<ApplicationUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

            
        public async Task<IActionResult> Index()
        {
            //Obtiene el usuario actul
            var currentUser = await _userManager.GetUserAsync(User);
            //Verifica que halla un usuario logeado, 
            //en caso contrario fuerza el logeo con Challenge().    
            if(currentUser == null)
                return Challenge();

            var items = await _todoItemService.GetIncompleteItemsAsync( currentUser);

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
            
            //Obtiene el usuario actul
            var currentUser = await _userManager.GetUserAsync(User);
            //Verifica que halla un usuario logeado, 
            //en caso contrario fuerza el logeo con Challenge().    
            if(currentUser == null)
                return Challenge();


            var successful = await _todoItemService.AddItemAsync(newItem, currentUser);
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

            //Obtiene el usuario actul
            var currentUser = await _userManager.GetUserAsync(User);
            //Verifica que halla un usuario logeado, 
            //en caso contrario fuerza el logeo con Challenge().    
            if(currentUser == null)
                return Challenge();

            var successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }


    }
}