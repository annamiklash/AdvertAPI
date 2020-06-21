using System;
using System.Collections.Generic;

namespace AdvertAPI.Models
{
    public class CampaignResponseWrapper
    {
        public int CampaignId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerSquareMeter { get; set; }
        public ClientWrapper Client { get; set; }
        public List<BannerWrapper> Banners { get; set; }
    }
}