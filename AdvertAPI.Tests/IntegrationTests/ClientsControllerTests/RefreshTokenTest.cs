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
    public class RefreshTokenTest : IClassFixture<WebApplicationFactory<AdvertAPI.Startup>>
    {
        private HttpClient Client { get; }

        public RefreshTokenTest(WebApplicationFactory<AdvertAPI.Startup> fixture)
        {
            Client = fixture.CreateClient();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        }
        
        [Fact]
        public async Task REFRESH_TOKEN_CORRECT()
        {
            var loginJSON = "{\"Login\": \"Jan125Test2\"," +
                            "\"Password\": \"asd124\"}";
            var loginBody = new StringContent(loginJSON,
                Encoding.UTF8,
                "application/json");
            var httpResponseLogin = await Client.PostAsync("/api/clients/login", loginBody);
            httpResponseLogin.StatusCode.Should().Be(HttpStatusCode.Created);

            var loginResponse =
                JsonConvert.DeserializeObject<LoginResponse>(await httpResponseLogin.Content.ReadAsStringAsync());
            var refreshToken = loginResponse.RefreshToken;

            var refreshJson = "{\"RefreshToken\": \"" + refreshToken + "\"}";
            var refreshBody = new StringContent(refreshJson,
                Encoding.UTF8,
                "application/json");
            var httpResponseRefresh = await Client.PostAsync("/api/clients/refresh", refreshBody);
            httpResponseRefresh.StatusCode.Should().Be(HttpStatusCode.Created);
            
            var refreshTokenResponse =
                JsonConvert.DeserializeObject<RefreshTokenResponse>(await httpResponseRefresh.Content.ReadAsStringAsync());
            
            refreshTokenResponse.AccessToken.Should().NotBeNullOrEmpty();
            refreshTokenResponse.RefreshToken.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public async Task REFRESH_TOKEN_INCORRECT()
        {
            var refreshToken = "af9ced14-eb0f-41da-982b-6ad356a6e34c";
            var refreshJson = "{\"RefreshToken\": \"" + refreshToken + "\"}";
            var refreshBody = new StringContent(refreshJson,
                Encoding.UTF8,
                "application/json");
            var httpResponseRefresh = await Client.PostAsync("/api/clients/refresh", refreshBody);
            httpResponseRefresh.StatusCode.Should().Be(HttpStatusCode.BadRequest);
           
        }
        
        [Fact]
        public async Task REFRESH_TOKEN_NULL()
        {
            string refreshToken = null;
            var refreshJson = "{\"RefreshToken\": \"" + refreshToken + "\"}";
            var refreshBody = new StringContent(refreshJson,
                Encoding.UTF8,
                "application/json");
            var httpResponseRefresh = await Client.PostAsync("/api/clients/refresh", refreshBody);
            httpResponseRefresh.StatusCode.Should().Be(HttpStatusCode.BadRequest);
           
        }
    }
}