using System;
using AdvertAPI.DTOs;
using AdvertAPI.Helpers;
using AdvertAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertAPI.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientDbService _dbService;
        public ClientsController(IClientDbService service)
        {
            _dbService = service;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            return Ok(_dbService.GetAllClients());
        }

        [HttpPost]
        public IActionResult AddNewClient(NewClientRequest request)
        {
            var errorList = ValidationHelper.ValidateNewClientRequest(request);
            if (errorList.Count > 0)
            {
                return BadRequest(errorList);
            }

            try
            {
                var response = _dbService.AddNewClient(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(RefreshTokenRequest request)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest("Request must contain a refresh token");
            }

            try
            {
                var response = _dbService.RefreshToken(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var errorList = ValidationHelper.ValidateLoginRequest(request);
            if (errorList.Count > 0)
            {
                return BadRequest(errorList);
            }
            
            try
            {
                var response = _dbService.AuthenticateClient(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}