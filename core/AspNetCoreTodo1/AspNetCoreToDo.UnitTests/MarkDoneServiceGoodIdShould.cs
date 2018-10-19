using System;
using System.Threading.Tasks;

using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;
using AspNetCoreToDo.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AspNetCoreToDo.UnitTests
{
    public class MarkDoneServiceGoodIdShould
    {
        [Fact]
        public async Task MarkDoneAnItemsWithGoodId()
        {
            //crea la base de datos en memoria.
            var options = new DbContextOptionsBuilder< ApplicationDbContext>()
                .UseInMemoryDatabase( databaseName: "Test_MarkDone").Options;

            //Crea el contexto necesario para realizar el test.
            //En este caso se crea el servicio ToDoItemService() y un usuario ficticio
            //y con esto se agrega un item a la base de datos. Luego se crea otro 
            //servicio MarkDoneAsync() para marcar como completado al item. 
            using(var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService( context);
                var fakeUser = new ApplicationUser{ Id= "fake-000", UserName= "fake@example.com"};
                var item = new ToDoItem{ Title="Testing?"};
                await service.AddItemAsync( item, fakeUser);

                //await service.MarkDoneAsync(item.Id, fakeUser);               
            }

            //Se crea otro contexto, y se verifica que solo tenga un Item.
            //Luego se crea un usuario con los mismos datos que el anterior y
            //se marcar como done el item almacenado en la base de datos. 
            using(var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService( context);
                var fakeUser = new ApplicationUser{ Id= "fake-000", UserName= "fake@example.com"};
                
                var itemsInDataBase = await context.Items.CountAsync();
                Assert.Equal(1, itemsInDataBase);
                
                var item = await context.Items.FirstAsync();
                Assert.False( item.IsDone);
                Assert.True( await service.MarkDoneAsync(item.Id, fakeUser));
                Assert.True( item.IsDone);
            }
        }
    }
}