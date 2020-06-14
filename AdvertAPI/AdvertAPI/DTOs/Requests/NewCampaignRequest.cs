namespace AdvertAPI.DTOs
{
    public class NewCampaignRequest
    {
        public int IdClient { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal PricePerSquareMeter { get; set; }
        public int FromIdBuilding { get; set; }
        public int ToIdBuilding { get; set; }
    }
}