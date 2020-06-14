using AdvertAPI.Models;

namespace AdvertAPI.Mappers
{
    public class BannerToBannerWrapper
    {
        public static BannerWrapper MapBannerToBannerWrapper(Banner banner)
        {
            return new BannerWrapper
            {
                BannerArea = banner.Area,
                BannerName = banner.Name,
                BannerPrice = banner.Price
            };
        }
    }
}