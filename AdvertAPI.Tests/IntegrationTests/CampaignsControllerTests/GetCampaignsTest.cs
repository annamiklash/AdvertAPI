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

namespace AdvertAPI.Tests.IntegrationTests.CampaignsControllerTests
{
    public class GetCampaignsTest : IClassFixture<WebApplicationFactory<AdvertAPI.Startup>>
    {
        private HttpClient Client { get; }

        public GetCampaignsTest(WebApplicationFactory<AdvertAPI.Startup> fixture)
        {
            Client = fixture.CreateClient();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        }

        [Fact]
        public async Task GET_CAMPAIGNS_CORRECT()
        {
            var loginJSON = "{\"Login\": \"Jan125Test2\"," +
                            "\"Password\": \"asd124\"}";
            var loginBody = new StringContent(loginJSON,
                Encoding.UTF8,
                "application/json");
            var httpResponseLogin = await Client.PostAsync("/api/clients/login", loginBody);
          
            var loginResponse =
                JsonConvert.DeserializeObject<LoginResponse>(await httpResponseLogin.Content.ReadAsStringAsync());
            var accessToken = loginResponse.AccessToken;
            
            Client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", accessToken);
            var httpResponseMessage = await Client.GetAsync("/api/campaigns");
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var getResponse =
                JsonConvert.DeserializeObject<CampaignsResponse>(await httpResponseMessage.Content.ReadAsStringAsync());

            getResponse.Campaigns.Should().HaveCount(6);

        }
        
        [Fact]
        public async Task GET_CAMPAIGNS_INCORRECT()
        {
            Client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", "IiwiYXVkIjoiVGVzdC5jb20ifQ.o2gKWRhV-63fG229yTNJ4AVWXgFZNtAzMtTm-87WwBo");
            var httpResponseMessage = await Client.GetAsync("/api/campaigns");
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        }
    }
}