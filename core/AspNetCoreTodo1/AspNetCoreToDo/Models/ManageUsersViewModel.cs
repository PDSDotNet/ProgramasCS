using System.Collections.Generic;

using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators{ get; set;}

        public ApplicationUser[] Everyone{ get; set;}
    }
}