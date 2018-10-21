using System;
using System.Threading.Tasks;

using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;
using AspNetCoreToDo.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AspNetCoreToDo.UnitTests
{
    public class MarkDoneServiceWrongIdNotShould
    {
        [Fact]
        public async Task MarkDoneAnItemsWithGoodId()
        {
            //crea la base de datos en memoria.
            var options = new DbContextOptionsBuilder< ApplicationDbContext>()
                .UseInMemoryDatabase( databaseName: "Test_MarkDoneWrongUser").Options;

            //Crea el contexto necesario para realizar el test.
            //En este caso se crea el servicio ToDoItemService() y un usuario ficticio,
            //y con esto se agrega un item a la base de datos. 
            using(var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService( context);
                var fakeUser = new ApplicationUser{ Id= "fake-000", UserName= "fake@example.com"};
                var item = new ToDoItem{ Title="Testing?"};
                await service.AddItemAsync( item, fakeUser);

                //await service.MarkDoneAsync(item.Id, fakeUser);               
            }

            //Se crea otro contexto, y se verifica que solo tenga un Item.
            //Luego se crea otro usuario y se intenta marcar como done el item almacenado
            //en la base de datos y creado por el primer usuario. 
            //Se crea el servicio MarkDoneAsync() intentar marcar como completado al item 
            //con el segundo usuario.
            using(var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService( context);
                var otherFkeUser = new ApplicationUser{ Id= "fake-000-ll", UserName= "fakeee@example.com"};
                //var otherFkeUser = new ApplicationUser{ Id= "fake-000", UserName= "fake@example.com"};

                var itemsInDataBase = await context.Items.CountAsync();
                Assert.Equal(1, itemsInDataBase);
                
                var item = await context.Items.FirstAsync();
                Assert.False( item.IsDone);
                Assert.False( await service.MarkDoneAsync(item.Id, otherFkeUser));
                Assert.False( item.IsDone);
            }
        }
    }
}