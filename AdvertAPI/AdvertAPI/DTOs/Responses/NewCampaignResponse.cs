using AdvertAPI.Models;

namespace AdvertAPI.DTOs
{
    public class NewCampaignResponse
    {
        public int CampaignId { get; set; }
        public BannerWrapper FirstBanner { get; set; }
        public BannerWrapper SecondBanner { get; set; }
        public decimal TotalPrice { get; set; }
    }
}