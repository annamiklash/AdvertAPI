using System.Collections.Generic;

namespace AdvertAPI.Models
{
    public class BannerWrapper
    {
        public decimal BannerPrice { get; set; }
        public decimal BannerArea { get; set; }
        public string BannerName { get; set; }
        public List<int> BuildingCoveredIdList { get; set; }
    }
}