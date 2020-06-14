namespace AdvertAPI.Models
{
    public class BestPriceWrapper
    {
        public decimal TotalPrice { get; set; }
        public BannerWrapper FirstBanner { get; set; }
        public BannerWrapper SecondBanner { get; set; }
    }
}