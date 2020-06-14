using AdvertAPI.DTOs;
using AdvertAPI.Models;

namespace AdvertAPI.Mappers
{
    public class CampaignToCampaignResponse
    {
        public static CampaignResponse MapToCampaignResponse(Campaign campaign, Client client)
        {
            return new CampaignResponse
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