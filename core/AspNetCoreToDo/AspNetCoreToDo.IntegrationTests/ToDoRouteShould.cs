using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreToDo.IntgrationTests
{
    public class ToDoRouteShould: IClassFixture< TestFixture>
    {
        public readonly HttpClient _client;

        public ToDoRouteShould( TestFixture fixture)
        {
            _client = fixture.Client;
        } 




        [Fact]
        public async Task ChallengeAnonymousUser()
        {
            //Arrange
            var request = new HttpRequestMessage( HttpMethod.Get, "/ToDo");


            //Act: request the /ToDo route
            var response = await _client.SendAsync(request);

            Assert.Equal( HttpStatusCode.Redirect, response.StatusCode);
            
            Assert.Equal("http://localhost:8888/Account" + "/Login?ReturnUrl=%2Ftodo", response.Headers.Location.ToString());

        }

    } 
}