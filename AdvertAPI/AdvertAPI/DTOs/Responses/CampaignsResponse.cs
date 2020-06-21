using System;
using System.Collections.Generic;
using AdvertAPI.Models;

namespace AdvertAPI.DTOs
{
    public class CampaignsResponse
    {
        public List<CampaignResponseWrapper> Campaigns { get; set; }
       
    }
}