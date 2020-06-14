using System;
using AdvertAPI.DTOs;
using AdvertAPI.Helpers;
using AdvertAPI.Models;
using AdvertAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertAPI.Controllers
{
    [Route("api/campaigns")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignsDbService _campaignsDbService;
        private readonly IClientDbService _clientDbService;


        public CampaignsController(ICampaignsDbService campaignsDbService, IClientDbService clientDbService)
        {
            _campaignsDbService = campaignsDbService;
            _clientDbService = clientDbService;
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult GetCampaigns()
        {
            return Ok(_campaignsDbService.GetAllCampaigns());
        }
        
        [HttpPost("add")]
        public IActionResult AddNewCampaign(NewCampaignRequest campaignRequest)
        {
            var errorList = ValidationHelper.ValidateNewCampaignRequest(campaignRequest);
            if (errorList.Count > 0)
            {
                return BadRequest(errorList);
            }

            try
            {
                var clientExists = _clientDbService.ClientExists(campaignRequest.IdClient);
                if (!clientExists)
                {
                    throw new Exception("Client with id " + campaignRequest.IdClient + " DOESNT EXIST");
                }

                var onSameStreet =
                    _campaignsDbService.BuildingsOnSameStreet(campaignRequest.FromIdBuilding,
                        campaignRequest.ToIdBuilding);
                if (!onSameStreet)
                {
                    throw new Exception("Buildings MUST be located on the same street");
                }

                BestPriceWrapper priceWrapper = _campaignsDbService.GetBestPrice(campaignRequest);
                var response = _campaignsDbService.AddNewCampaign(campaignRequest, priceWrapper);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}