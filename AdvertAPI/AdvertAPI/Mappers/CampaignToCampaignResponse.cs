using AdvertAPI.DTOs;
using AdvertAPI.Models;

namespace AdvertAPI.Mappers
{
    public class CampaignToCampaignResponse
    {
        public static CampaignResponseWrapper MapToCampaignResponse(Campaign campaign, Client client)
        {
            return new CampaignResponseWrapper
            {
                CampaignId = campaign.IdCampaign,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                PricePerSquareMeter = campaign.PricePerSquareMeter,
                Client = ClientToClientWrapper.MapToClientWrapper(client)
            };
        }
    }
}