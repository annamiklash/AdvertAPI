using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvertAPI.Controllers;
using AdvertAPI.DTOs;
using AdvertAPI.Helpers;
using AdvertAPI.Models;
using AdvertAPI.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AdvertAPI.Tests.UnitTests.Clients
{
    public class ClientsControllerTest
    {
        private ClientsController clientsController;

        private Mock<IClientDbService> mockDbService;

        public ClientsControllerTest()
        {
            mockDbService = new Mock<IClientDbService>();

            clientsController = new ClientsController(mockDbService.Object);
        }

        [Fact]
        public async Task GetAllClients_Ok()
        {
            //Arrange
            var targetList = new List<Client>
            {
                new Client
                {
                    IdClient = 123
                }
            };

            mockDbService.Setup(service => service.GetAllClients())
                .Returns(targetList);

            //Act
            var actionResult = clientsController.GetAllClients();

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var resultClientList = okObjectResult.Value as List<Client>;

            Assert.Equal(targetList, resultClientList);

            mockDbService.Verify(service => service.GetAllClients(), Times.Once);
        }

        [Fact]
        public void Login_VALIDATION_ERROR_BAD_REQUEST()
        {
            //Arrange
            var request = new LoginRequest();
            var targetErrorList = new List<Error>();
            targetErrorList.Add(
                new Error
                {
                    Field = "Login",
                    InvalidValue = request.Login,
                    Message = "Login field must be filled in"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "Password",
                    InvalidValue = request.Password,
                    Message = "Password field must be filled in"
                }
            );

            //Act
            var actionResult = clientsController.Login(request);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var resultClientList = badRequestObjectResult.Value as List<Error>;

            targetErrorList.Should().BeEquivalentTo(resultClientList);

            mockDbService.Verify(service => service.AuthenticateClient(request), Times.Never);
        }

        [Fact]
        public void Login_SUCCESS()
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                Login = "Jan125Test2",
                Password = "asd124"
            };

            var targetLoginResponse = new LoginResponse
            {
                AccessToken = "access",
                RefreshToken = "refresh"
            };

            mockDbService.Setup(service => service.AuthenticateClient(loginRequest))
                .Returns(targetLoginResponse);

            //Act
            var actionResult = clientsController.Login(loginRequest);
            //Assert
            var createdObjectResult = actionResult as ObjectResult;
            Assert.NotNull(createdObjectResult);
            Assert.Equal(201, createdObjectResult.StatusCode);

            var resultLoginResponse = createdObjectResult.Value as LoginResponse;
            Assert.Equal(targetLoginResponse, resultLoginResponse);
        }
        
        [Fact]
        public void Login_UNATHORIZED()
        {
            //Arrange
            var loginRequest = new LoginRequest
            {
                Login = "Jan125Test2",
                Password = "asd124"
            };

            var targetException = new Exception("sample error message");

            mockDbService.Setup(service => service.AuthenticateClient(loginRequest))
                .Throws(targetException);

            //Act
            var actionResult = clientsController.Login(loginRequest);
            
            //Assert
            var unauthorizedObjectResult = actionResult as UnauthorizedObjectResult;
            Assert.NotNull(unauthorizedObjectResult);

            var errorMessage = unauthorizedObjectResult.Value as string;
            Assert.Equal(targetException.Message, errorMessage);
        }

        [Fact]
        public void Refresh_VALIDATION_ERROR_BAD_REQUEST()
        {
            //Arrange
            var refreshTokenRequest = new RefreshTokenRequest();

            //Act
            var actionResult = clientsController.RefreshToken(refreshTokenRequest);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var errorMessage = badRequestObjectResult.Value as string;
            Assert.Equal("Request must contain a refresh token", errorMessage);
        }

        [Fact]
        public void Refresh_SUCCESS()
        {
            //Arrange
            var refreshTokenRequest = new RefreshTokenRequest
            {
                RefreshToken = "token"
            };

            var targetTokenResponse = new RefreshTokenResponse()
            {
                AccessToken = "access",
                RefreshToken = "refresh"
            };

            mockDbService.Setup(service => service.RefreshToken(refreshTokenRequest))
                .Returns(targetTokenResponse);

            //Act
            var actionResult = clientsController.RefreshToken(refreshTokenRequest);

            //Assert
            var createdObjectResult = actionResult as ObjectResult;
            Assert.NotNull(createdObjectResult);
            Assert.Equal(201, createdObjectResult.StatusCode);

            var resultTokenResponse = createdObjectResult.Value as RefreshTokenResponse;
            Assert.Equal(targetTokenResponse, resultTokenResponse);
        }

        [Fact]
        public void Refresh_UNHANDLED_EXCEPTION_BAD_REQUEST()
        {
            //Arrange
            var refreshTokenRequest = new RefreshTokenRequest
            {
                RefreshToken = "token"
            };

            var targetException = new Exception("sample error message");

            mockDbService.Setup(service => service.RefreshToken(refreshTokenRequest))
                .Throws(targetException);

            //Act
            var actionResult = clientsController.RefreshToken(refreshTokenRequest);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var errorMessage = badRequestObjectResult.Value as string;
            Assert.Equal(targetException.Message, errorMessage);
        }

        [Fact]
        public void AddNewClient_VALIDATION_ERROR_BAD_REQUEST()
        {
            //Arrange
            var request = new NewClientRequest
            {
                FirstName = "123",
                LastName = "*&%^$",
                Email = "hello",
                Phone = "abc",
                Login = null,
                Password = ""
            };

            var targetErrorList = new List<Error>();
            targetErrorList.Add(
                new Error
                {
                    Field = "FirstName",
                    InvalidValue = request.FirstName,
                    Message = "Wrong format for First Name. Should be ^[A-Z][-a-zA-Z]+$"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "LastName",
                    InvalidValue = request.LastName,
                    Message = "Wrong format for Last Name. Should be ^[A-Z][-a-zA-Z]+$"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "Email",
                    InvalidValue = request.Email,
                    Message = "Wrong format for email"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "Phone",
                    InvalidValue = request.Phone,
                    Message = "Wrong format for phone number. Should be ^\\d{3}-\\d{3}-\\d{3}$"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "Login",
                    InvalidValue = request.Login,
                    Message = "Login field must be filled in"
                }
            );
            targetErrorList.Add(
                new Error
                {
                    Field = "Password",
                    InvalidValue = request.Password,
                    Message = "Password field must be filled in"
                }
            );
            //Act
            var actionResult = clientsController.AddNewClient(request);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var resultClientList = badRequestObjectResult.Value as List<Error>;

            targetErrorList.Should().BeEquivalentTo(resultClientList);

            mockDbService.Verify(service => service.AddNewClient(request), Times.Never);
        }

        [Fact]
        public void AddNewClient_SUCCESS()
        {
            //Arrange
            var request = new NewClientRequest
            {
                FirstName = "Jan",
                LastName = "Kotowski",
                Email = "hello@gmail.com",
                Phone = "111-222-333",
                Login = "hello_login",
                Password = "pass"
            };

            var targetResponse = new NewClientResponse
            {
                AccessToken = "access",
                RefreshToken = "refresh"
            };

            mockDbService.Setup(service => service.AddNewClient(request))
                .Returns(targetResponse);

            //Act
            var actionResult = clientsController.AddNewClient(request);

            //Assert
            var createdObjectResult = actionResult as ObjectResult;
            Assert.NotNull(createdObjectResult);
            Assert.Equal(201, createdObjectResult.StatusCode);

            var resultResponse = createdObjectResult.Value as NewClientResponse;
            Assert.Equal(targetResponse, resultResponse);

            mockDbService.Verify(service => service.AddNewClient(request), Times.Once);
        }

        [Fact]
        public void AddNewClient_UNHANDELED_EXCEPTION_BAD_REQUEST()
        {
            //Arrange
            var request = new NewClientRequest
            {
                FirstName = "Jan",
                LastName = "Kotowski",
                Email = "hello@gmail.com",
                Phone = "111-222-333",
                Login = "hello_login",
                Password = "pass"
            };

            var targetException = new Exception("sample error message");

            mockDbService.Setup(service => service.AddNewClient(request))
                .Throws(targetException);

            //Act
            var actionResult = clientsController.AddNewClient(request);

            //Assert
            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var errorMessage = badRequestObjectResult.Value as string;
            Assert.Equal(targetException.Message, errorMessage);

            mockDbService.Verify(service => service.AddNewClient(request), Times.Once);
        }
    }
}