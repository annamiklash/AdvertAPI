using System;
using System.Collections.Generic;
using AdvertAPI.Models;

namespace AdvertAPI.DTOs
{
    public class CampaignResponse
    {
        public int CampaignId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerSquareMeter { get; set; }
        public ClientWrapper Client { get; set; }
        public List<BannerWrapper> Banners { get; set; }
    }
}