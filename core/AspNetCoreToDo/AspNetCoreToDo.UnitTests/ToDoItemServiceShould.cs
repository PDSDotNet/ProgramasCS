using System;
using System.Threading.Tasks;

using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;
using AspNetCoreToDo.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AspNetCoreToDo.UnitTests
{
    public class ToDoItemServiceShould: IDisposable
    {
        private DbContextOptionsBuilder< ApplicationDbContext> ODB;
        //ODB: Options Data Base.

        public ToDoItemServiceShould()
        {
            //crea las opciones para conectarce a la base de datos en memoria.
            ODB = new DbContextOptionsBuilder< ApplicationDbContext>()
                .UseInMemoryDatabase( databaseName: "Test_BD");
        }

        public void Dispose()
        {
            //CDB: Comtext Data Base.
            var CDB = new ApplicationDbContext(ODB.Options);
            //CDB.Dispose();
            //CDB.Items.Remove(CDB.Items.Find(1));
            //CDB.Items.Remove(CDB.Items.Single(a=>a.Title="Testing?"));
            CDB.Database.EnsureDeleted();
        }

        private async Task SetUp()
        {
            //Crea el contexto (conexion con la base de datos) para poder crear 
            //el servicio ToDoItemService. Luego se crea un usuario 
            //ficticio con el que se agrega un item a la base de datos mediante AddItemAsync(). 
            using(var context = new ApplicationDbContext(ODB.Options))
            {
                var service = new ToDoItemService( context);
                var fakeUser = new ApplicationUser{ Id= "fake-000", UserName= "fake@example.com"};
                var item = new ToDoItem{ Title="Testing?"};
                await service.AddItemAsync( item, fakeUser);            
            }
        }




        
        [Fact]/**/
        public async Task AddNewItemAsIncompleteWhitDueDate()
        {
            await SetUp();

            //Se crea otro contexto, y se verifica que solo tenga un Item.
            //Luego se obtiene el primer item y se verifiva que el coincida el Tile
            //y que no este marcado como done. 
            using(var CDB = new ApplicationDbContext(ODB.Options))
            {
                var itemsInDataBase = await CDB.Items.CountAsync();
                Assert.Equal(1, itemsInDataBase);
                
                var item = await CDB.Items.FirstAsync();
                Assert.Equal("Testing?", item.Title);
                //Assert.Equal(false, item.IsDone);
                Assert.True( false == item.IsDone);
                
                var difference = DateTimeOffset.Now.AddDays(3) - item.DueAt;
                Assert.True(difference < TimeSpan.FromSeconds(3));
            }
        }




        [Fact]/**/ 
        public async Task MarkDoneAnItemsWithGoodId()
        {
            await SetUp();

            //Se crea otro contexto, y se verifica que solo tenga un Item.
            //Luego se crea otro usuario (con el distinto Id) y se intenta marcar 
            //como done el item almacenado en la base de datos usando MarkDoneAsync(). 
            using(var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new ToDoItemService( CDB);
                var otherFakeUser = new ApplicationUser{ Id= "fake-000", UserName= "fake@example.com"};
                
                var itemsInDataBase = await CDB.Items.CountAsync();
                Assert.Equal(1, itemsInDataBase);
                
                var item = await CDB.Items.FirstAsync();
                Assert.False( item.IsDone);
                bool result = await service.MarkDoneAsync(item.Id, otherFakeUser);
                Assert.True( result);
                Assert.True( item.IsDone);
            }
        }






        [Fact] /**/
        public async Task MarkDoneAnItemsWithWrongId()
        {
            await SetUp();

            //Se crea otro contexto, y se verifica que solo tenga un Item.
            //Luego se crea otro usuario (con el distinto Id) y se intenta marcar 
            //como done el item almacenado en la base de datos usando MarkDoneAsync(). 
            using(var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new ToDoItemService( CDB);
                var otherFakeUser = new ApplicationUser{ Id= "fake-000-ll", UserName= "fakeee@example.com"};
                
                var itemsInDataBase = await CDB.Items.CountAsync();
                Assert.Equal(1, itemsInDataBase);
                
                var item = await CDB.Items.FirstAsync();
                Assert.False( item.IsDone);
                bool result = await service.MarkDoneAsync(item.Id, otherFakeUser);
                Assert.False( result);
                Assert.False( item.IsDone);
            }
        }


        [Fact]/**/
        public async Task ReturnOwnItems()
        {
            //SetUp.
            //Crea el contexto (conexion con la base de datos) para poder crear 
            //el servicio ToDoItemService.
            //Luego se crean tres usuarios ficticios,
            //y se agregar 5 items a cada uno en la base de datos. 
            using(var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new ToDoItemService( CDB);

                for(int i = 1; i < 4; i++)
                {
                    string usr = "fake-00"+ i;
                    string mail = "fake"+ i + "@example.com";
                    var fakeUser = new ApplicationUser{ Id= usr, UserName= mail};
                    for(int j = 1; j < 6; j++)
                    {
                        string itemTitle = "Task_"+ j;
                        var item = new ToDoItem{ Title=itemTitle};
                        await service.AddItemAsync( item, fakeUser);
                    }
                }
                             
            }

            //Se crea otro contexto, y se verifica que tenga 15 Items.
            //Luego se crea un usuario y se listan todas las tareas contando las tareas 
            //que le pertenecen al usuario creado(5) y a las de los otros usuarios(10).
            using(var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new ToDoItemService( CDB);
                var FakeUser2 = new ApplicationUser{ Id= "fake-002", UserName= "fak2@example.com"};
                

                var itemsInDataBase = await CDB.Items.CountAsync();
                Assert.Equal(15, itemsInDataBase);
                
                int elementosFakeUser2 = 0;
                int elementosOtherFakeUser = 0;
                foreach(var elemento in CDB.Items)
                {
                    if( elemento.UserId == FakeUser2.Id)
                        elementosFakeUser2 ++;
                    else
                        elementosOtherFakeUser++;
                }
                
                Assert.Equal( 5, elementosFakeUser2);
                Assert.Equal( 10, elementosOtherFakeUser);
            }
        }





    }
}