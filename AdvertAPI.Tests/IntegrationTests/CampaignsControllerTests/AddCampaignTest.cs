using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AdvertAPI.Tests.IntegrationTests.CampaignsControllerTests
{
    public class AddCampaignTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient Client { get; }

        public AddCampaignTest(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        }

        [Fact]
        public async Task GET_CAMPAIGNS_INCORRECT_STARTDATE()
        {
            var json =
                "{\"IdClient\": 1," +
                "\"StartDate\": \"wrong\"," +
                "\"EndDate\": \"2020-3-1\"," +
                "\"PricePerSquareMeter\":35," +
                "\"FromIdBuilding\": 1," +
                "\"ToIdBuilding\": 2}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/campaigns/add", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            
        }

        [Fact]
        public async Task GET_CAMPAIGNS_INCORRECT_ENDDATE()
        {
            var json =
                "{\"IdClient\": 1," +
                "\"StartDate\": \"2020-3-1\"," +
                "\"EndDate\": \"wrong\"," +
                "\"PricePerSquareMeter\":35," +
                "\"FromIdBuilding\": 1," +
                "\"ToIdBuilding\": 2}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/campaigns/add", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GET_CAMPAIGNS_INCORRECT_PRICE_PER_SQUARE_METER()
        {
            var json =
                "{\"IdClient\": 1," +
                "\"StartDate\": \"2020-2-1\"," +
                "\"EndDate\": \"2020-3-1\"," +
                "\"PricePerSquareMeter\":abc," +
                "\"FromIdBuilding\": 1," +
                "\"ToIdBuilding\": 2}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/campaigns/add", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        

        [Fact]
        public async Task GET_CAMPAIGNS_CLIENT_ID_DOESNT_EXIST()
        {
            var json =
                "{\"IdClient\": 25," +
                "\"StartDate\": \"2020-2-1\"," +
                "\"EndDate\": \"2020-3-1\"," +
                "\"PricePerSquareMeter\":35," +
                "\"FromIdBuilding\": 1," +
                "\"ToIdBuilding\": 2}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/campaigns/add", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GET_CAMPAIGNS_BUILDINGS_NOT_ON_SAME_STREET()
        {
            var json =
                "{\"IdClient\": 1," +
                "\"StartDate\": \"2020-2-1\"," +
                "\"EndDate\": \"2020-3-1\"," +
                "\"PricePerSquareMeter\":35," +
                "\"FromIdBuilding\": 1," +
                "\"ToIdBuilding\": 4}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/campaigns/add", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GET_CAMPAIGNS_ENDDATE_BEFORE_STARTDATE()
        {
            var json =
                "{\"IdClient\": 1," +
                "\"StartDate\": \"2020-5-1\"," +
                "\"EndDate\": \"2020-2-1\"," +
                "\"PricePerSquareMeter\":35," +
                "\"FromIdBuilding\": 1," +
                "\"ToIdBuilding\": 2}";
            var body = new StringContent(json,
                Encoding.UTF8,
                "application/json"); //CONTENT-TYPE header
            var httpResponseMessage = await Client.PostAsync("/api/campaigns/add", body);
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}