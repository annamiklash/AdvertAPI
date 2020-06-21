using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AdvertAPI.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace AdvertAPI.Tests.IntegrationTests.ClientsControllerTests
{
    public class LoginTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient Client { get; }

        public LoginTest(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        }
        
        [Fact]
        public async Task LOGIN_SUCCESS()
        {
            var json = "{\"Login\": \"Jan125Test2\"," +
                       "\"Password\": \"asd124\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var response = await Client.PostAsync("/api/clients/login", body);
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var loginResponse =
                JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());
            loginResponse.AccessToken.Should().NotBeNullOrEmpty();
            loginResponse.RefreshToken.Should().NotBeNullOrEmpty();
            
        }

        [Fact]
        public async Task LOGIN_USERNAME_INCORRECT()
        {
            var json = "{\"Login\": \"Hello\"," +
                       "\"Password\": \"asd124\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var response = await Client.PostAsync("/api/clients/login", body);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task LOGIN_LOGIN_INCORRECT()
        {
            var json = "{\"Login\": \"Jan125Test2\"," +
                       "\"Password\": \"aaasd124\"}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var response = await Client.PostAsync("/api/clients/login", body);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

    }
}