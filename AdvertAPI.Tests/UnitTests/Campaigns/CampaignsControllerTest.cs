using System.Collections.Generic;
using AdvertAPI.Controllers;
using AdvertAPI.DTOs;
using AdvertAPI.Helpers;
using AdvertAPI.Models;
using AdvertAPI.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AdvertAPI.Tests.UnitTests.Campaigns
{
    public class CampaignsControllerTest
    {
        private CampaignsController _campaignsController;

        private Mock<IClientDbService> _clientsMockDbService;
        private Mock<ICampaignsDbService> _campaignsMockDbService;

        public CampaignsControllerTest()
        {
            _clientsMockDbService = new Mock<IClientDbService>();
            _campaignsMockDbService = new Mock<ICampaignsDbService>();

            _campaignsController =
                new CampaignsController(_campaignsMockDbService.Object, _clientsMockDbService.Object);
        }

        [Fact]
        public void GetCampaigns_SUCCESS()
        {
            //Arrange
            var targetResponse = new CampaignsResponse
            {
                Campaigns = new List<CampaignResponseWrapper>
                {
                    new CampaignResponseWrapper
                    {
                        CampaignId = 123
                    }
                }
            };

            _campaignsMockDbService.Setup(service => service.GetAllCampaigns())
                .Returns(targetResponse);

            //Act
            var actionResult = _campaignsController.GetCampaigns();

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var resultResponse = okObjectResult.Value as CampaignsResponse;

            Assert.Equal(targetResponse, resultResponse);

            _campaignsMockDbService.Verify(service => service.GetAllCampaigns(), Times.Once);
        }

        [Fact]
        public void AddNewCampaign_VALIDATION_ERROR_BAD_REQUEST()
        {
            //Arrange
            var request = new NewCampaignRequest
            {
                StartDate = "bad date",
                PricePerSquareMeter = 123,
                EndDate = "bad date"
            };

            var targetErrorList = new List<Error>();
            targetErrorList.Add(
                new Error
                {
                    Field = "StartDate",
                    InvalidValue = request.StartDate,
                    Message = "Date doesnt match regex ^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$)"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "EndDate",
                    InvalidValue = request.EndDate,
                    Message = "Date doesnt match regex ^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$)"
                }
            );

            //Act
            var actionResult = _campaignsController.AddNewCampaign(request);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var resultErrorList = badRequestObjectResult.Value as List<Error>;

            targetErrorList.Should().BeEquivalentTo(resultErrorList);

            _clientsMockDbService.Verify(service => service.ClientExists(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void AddNewCampaign_VALIDATION_ERROR_IS_START_BEFORE_END_BAD_REQUEST()
        {
            //Arrange
            var request = new NewCampaignRequest
            {
                StartDate = "2020-07-01",
                EndDate = "2020-01-01"
            };

            var targetErrorList = new List<Error>();
            targetErrorList.Add(
                new Error
                {
                    Field = "StartDate",
                    InvalidValue = request.StartDate,
                    Message = "StartDate should be BEFORE EndDate"
                }
            );

            //Act
            var actionResult = _campaignsController.AddNewCampaign(request);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var resultErrorList = badRequestObjectResult.Value as List<Error>;

            targetErrorList.Should().BeEquivalentTo(resultErrorList);

            _clientsMockDbService.Verify(service => service.ClientExists(It.IsAny<int>()), Times.Never);
            _campaignsMockDbService.Verify(service => service.BuildingsOnSameStreet(It.IsAny<int>(), It.IsAny<int>()),
                Times.Never);
            _campaignsMockDbService.Verify(service => service.GetBestPrice(It.IsAny<NewCampaignRequest>()),
                Times.Never);
            _campaignsMockDbService.Verify(
                service => service.AddNewCampaign(It.IsAny<NewCampaignRequest>(), It.IsAny<BestPriceWrapper>()),
                Times.Never);
        }

        [Fact]
        public void AddNewCampaign_SUCCESS()
        {
            //Arrange
            var request = new NewCampaignRequest
            {
                StartDate = "2020-07-01",
                EndDate = "2020-08-01",
                IdClient = 3,
                FromIdBuilding = 1,
                ToIdBuilding = 2
            };

            var priceWrapper = new BestPriceWrapper
            {
                FirstBanner = new BannerWrapper
                {
                    BannerName = "abc"
                },
                SecondBanner = new BannerWrapper
                {
                    BannerName = "cba"
                },
                TotalPrice = new decimal(1000)
            };

            var targetResponse = new NewCampaignResponse
            {
                CampaignId = 100
            };

            _clientsMockDbService.Setup(service => service.ClientExists(request.IdClient))
                .Returns(true);
            _campaignsMockDbService.Setup(service =>
                    service.BuildingsOnSameStreet(request.FromIdBuilding, request.ToIdBuilding))
                .Returns(true);
            _campaignsMockDbService.Setup(service => service.GetBestPrice(request))
                .Returns(priceWrapper);
            _campaignsMockDbService.Setup(service => service.AddNewCampaign(request, priceWrapper))
                .Returns(targetResponse);
            //Act
            var actionResult = _campaignsController.AddNewCampaign(request);

            //Assrt
            var createdObjectResult = actionResult as ObjectResult;
            Assert.NotNull(createdObjectResult);
            Assert.Equal(201, createdObjectResult.StatusCode);

            var resultResponse = createdObjectResult.Value as NewCampaignResponse;
            Assert.Equal(targetResponse, resultResponse);
        }

        [Fact]
        public void AddNewCampaign_CLIENT_DOESNT_EXIST_BAD_REQUEST()
        {
            //Arrange
            var request = new NewCampaignRequest
            {
                StartDate = "2020-07-01",
                EndDate = "2020-08-01",
                IdClient = 3,
                FromIdBuilding = 1,
                ToIdBuilding = 2
            };

            var targetErrorMessage = "Client with id " + request.IdClient + " DOESNT EXIST";

            _clientsMockDbService.Setup(service => service.ClientExists(request.IdClient))
                .Returns(false);

            //Act
            var actionResult = _campaignsController.AddNewCampaign(request);

            //Assrt
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var errorMessage = badRequestObjectResult.Value as string;
            Assert.Equal(targetErrorMessage, errorMessage);
        }

        [Fact]
        public void AddNewCampaign_NOT_ON_SAME_STREET_BAD_REQUEST()
        {
            //Arrange
            var request = new NewCampaignRequest
            {
                StartDate = "2020-07-01",
                EndDate = "2020-08-01",
                IdClient = 3,
                FromIdBuilding = 1,
                ToIdBuilding = 2
            };

            var targetErrorMessage = "Buildings MUST be located on the same street";

            _clientsMockDbService.Setup(service => service.ClientExists(request.IdClient))
                .Returns(true);
            _campaignsMockDbService.Setup(service =>
                    service.BuildingsOnSameStreet(request.FromIdBuilding, request.ToIdBuilding))
                .Returns(false);

            //Act
            var actionResult = _campaignsController.AddNewCampaign(request);

            //Assrt
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var errorMessage = badRequestObjectResult.Value as string;
            Assert.Equal(targetErrorMessage, errorMessage);
        }
    }
}