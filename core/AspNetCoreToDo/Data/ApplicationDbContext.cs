using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Data
{
    public class ApplicationDbContext : IdentityDbContext /*<ApplicationUser> */
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating( builder);
        }


        public DbSet<ToDoItem> Items { get; set; }
    }
}
