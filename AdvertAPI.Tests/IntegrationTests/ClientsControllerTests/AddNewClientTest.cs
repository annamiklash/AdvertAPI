using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AdvertAPI.Context;
using AdvertAPI.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace AdvertAPI.Tests.IntegrationTests.ClientsControllerTests
{
    public class AddNewClientTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient Client { get; }
        private WebApplicationFactory<Startup> _fixture { get; }
        private IServiceScopeFactory _scopeFactory { get; }

        public AddNewClientTest(WebApplicationFactory<Startup> fixture)
        {
            //fixture.Server.PreserveExecutionContext = true;
            _fixture = fixture;
            _scopeFactory = _fixture.Server.Services.GetService<IServiceScopeFactory>();

            Client = fixture.CreateClient();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        }

        // [Fact]
        // public async Task ADD_NEW_CLIENT_SUCCESS()
        // {
        //     using (var scope = _scopeFactory.CreateScope())
        //     {
        //         var context = scope.ServiceProvider.GetService<MyDbContext>();
        //         await using (var transaction = await context.Database.BeginTransactionAsync())
        //         {
        //             var json =
        //                 "{\"FirstName\": \"Jantest\"," +
        //                 "\"LastName\": \"Kowalskitest\"," +
        //                 "\"Email\": \"test@gmail.com\"," +
        //                 "\"Phone\": \"454-232-222\"," +
        //                 "\"Login\": \"Jan125Test3\"," +
        //                 "\"Password\": \"password\"}";
        //             var body = new StringContent(json,
        //                 Encoding.UTF8,
        //                 "application/json"); //CONTENT-TYPE header
        //             var httpResponseMessage = await Client.PostAsync("/api/clients", body);
        //             httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        //
        //             var newClientResponse =
        //                 JsonConvert.DeserializeObject<NewClientResponse>(
        //                     await httpResponseMessage.Content.ReadAsStringAsync());
        //             newClientResponse.AccessToken.Should().NotBeNullOrEmpty();
        //             newClientResponse.RefreshToken.Should().NotBeNullOrEmpty();
        //
        //             await transaction.RollbackAsync();
        //         }
        //     }
        // }

        [Fact]
        public async Task ADD_NEW_CLIENT_FIRST_NAME_WRONG_FORMAT()
        {
            var json =
                "{\"FirstName\": \"123Jan\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"test@gmail.com\"," +
                "\"Phone\": \"454-232-222\"," +
                "\"Login\": \"Jan125Test3\"," +
                "\"Password\": \"password\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_LAST_NAME_WRONG_FORMAT()
        {
            var json =
                "{\"FirstName\": \"Jan\"," +
                "\"LastName\": \"123Kowalski\"," +
                "\"Email\": \"test@gmail.com\"," +
                "\"Phone\": \"454-232-222\"," +
                "\"Login\": \"Jan125Test3\"," +
                "\"Password\": \"password\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_EMAIL_WRONG_FORMAT()
        {
            var json =
                "{\"FirstName\": \"123\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"JanKowalski\"," +
                "\"Phone\": \"454-232-222\"," +
                "\"Login\": \"Jan125Test3\"," +
                "\"Password\": \"password\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_PHONE_WRONG_FORMAT()
        {
            var json =
                "{\"FirstName\": \"123\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"JanKowalski@gmail.com\"," +
                "\"Phone\": \"phone number\"," +
                "\"Login\": \"Jan125Test3\"," +
                "\"Password\": \"password\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_LOGIN_EMPTY()
        {
            var json =
                "{\"FirstName\": \"123\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"JanKowalski@gmail.com\"," +
                "\"Phone\": \"333-444-555\"," +
                "\"Login\": \"\"," +
                "\"Password\": \"password\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_LOGIN_NULL()
        {
            var json =
                "{\"FirstName\": \"123\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"JanKowalski@gmail.com\"," +
                "\"Phone\": \"333-444-555\"," +
                "\"Login\": null," +
                "\"Password\": \"password\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_PASSWORD_EMPTY()
        {
            var json =
                "{\"FirstName\": \"123\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"JanKowalski@gmail.com\"," +
                "\"Phone\": \"333-444-555\"," +
                "\"Login\": \"Jan125Test3\"," +
                "\"Password\": \"\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task ADD_NEW_CLIENT_PASSWORD_NULL()
        {
            var json =
                "{\"FirstName\": \"123\"," +
                "\"LastName\": \"Kowalskitest\"," +
                "\"Email\": \"JanKowalski@gmail.com\"," +
                "\"Phone\": \"333-444-555\"," +
                "\"Login\": \"Jan125Test3\"," +
                "\"Password\": null}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/clients", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}