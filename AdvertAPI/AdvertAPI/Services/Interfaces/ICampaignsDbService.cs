using System.Collections.Generic;
using AdvertAPI.DTOs;
using AdvertAPI.Models;

namespace AdvertAPI.Services
{
    public interface ICampaignsDbService
    {
        bool BuildingsOnSameStreet(int fromId, int toId);
        BestPriceWrapper GetBestPrice(NewCampaignRequest request);
        NewCampaignResponse AddNewCampaign(NewCampaignRequest request, BestPriceWrapper wrapper);

        List<CampaignResponse> GetAllCampaigns();

    }
}