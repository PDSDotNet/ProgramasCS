using System;
using System.Threading.Tasks;

using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;
using AspNetCoreToDo.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AspNetCoreToDo.UnitTests
{
    public class GetIncompleteItemsAsyncShould
    {
        /*[Fact]*/
        public async Task ReturnOwnItems()
        {
            //crea la base de datos en memoria.
            var options = new DbContextOptionsBuilder< ApplicationDbContext>()
                .UseInMemoryDatabase( databaseName: "Test_GetIncompletItemsAsync").Options;

            //Crea el contexto necesario para realizar el test.
            //En este caso se crea el servicio ToDoItemService() y tres usuarios ficticios,
            //y se le van a agregar 5 items a cada uno. 
            using(var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService( context);

                for(int i = 0; i< 3; i++)
                {
                    string usr = "fake-00"+ i;
                    string mail = "fake"+ i + "@example.com";
                    var fakeUser = new ApplicationUser{ Id= usr, UserName= mail};
                    for(int j = 0; j<0;j++)
                    {
                        string itemTitle = "fake-00"+ i;
                        var item = new ToDoItem{ Title=itemTitle};
                        await service.AddItemAsync( item, fakeUser);
                    }
                }
                             
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