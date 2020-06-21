using System;
using System.Collections.Generic;
using System.Linq;
using AdvertAPI.Context;
using AdvertAPI.DTOs;
using AdvertAPI.Mappers;
using AdvertAPI.Models;

namespace AdvertAPI.Services
{
    public class CampaignsDbService : ICampaignsDbService
    {
        private readonly MyDbContext _context;
        private readonly IClientDbService _clientDb;

        public CampaignsDbService(MyDbContext context, IClientDbService clientDb)
        {
            _context = context;
            _clientDb = clientDb;
        }

        public CampaignsResponse GetAllCampaigns()
        {
            List<Client> clientList = _context.Client.ToList();
            List<Campaign> campaignsList = _context.Campaign.ToList();
            List<Banner> bannersList = _context.Banner.ToList();
            List<CampaignResponseWrapper> campaignResponses = new List<CampaignResponseWrapper>();

            foreach (var campaign in campaignsList)
            {
                var client = _clientDb.GetClientById(campaign.IdClient);
                CampaignResponseWrapper campaignsResponse =
                    CampaignToCampaignResponse.MapToCampaignResponse(campaign, client);
                List<BannerWrapper> bannerWrappers = new List<BannerWrapper>();

                foreach (var banner in campaign.Banner)
                {
                    BannerWrapper bannerWrapper = BannerToBannerWrapper.MapBannerToBannerWrapper(banner);
                    bannerWrappers.Add(bannerWrapper);
                }

                campaignsResponse.Banners = bannerWrappers;
                campaignResponses.Add(campaignsResponse);
            }

            campaignResponses = campaignResponses.OrderByDescending(response => response.StartDate).ToList();
            return new CampaignsResponse
            {
                Campaigns = campaignResponses
            };
        }


        public bool BuildingsOnSameStreet(int fromId, int toId)
        {
            var fromExists = BuildingExists(fromId);
            var toExists = BuildingExists(toId);

            if (!fromExists)
            {
                throw new Exception("Building with id " + fromId + " DOESNT EXIST");
            }

            if (!toExists)
            {
                throw new Exception("Building with id " + toId + " DOESNT EXIST");
            }

            var fromStreet = GetStreet(fromId);
            var toStreet = GetStreet(toId);

            return fromStreet.Equals(toStreet);
        }


        public BestPriceWrapper GetBestPrice(NewCampaignRequest request)
        {
            var buildings = GetAllBuildingsInBetween(request.FromIdBuilding, request.ToIdBuilding);
            return CalculateTotalPrice(buildings, request.PricePerSquareMeter);
        }

        public NewCampaignResponse AddNewCampaign(NewCampaignRequest request, BestPriceWrapper wrapper)
        {
            int campaignId = CreateCampaign(request);
            CreateBanner(wrapper.FirstBanner, campaignId);
            CreateBanner(wrapper.SecondBanner, campaignId);

            return new NewCampaignResponse
            {
                CampaignId = campaignId,
                FirstBanner = wrapper.FirstBanner,
                SecondBanner = wrapper.SecondBanner,
                TotalPrice = wrapper.TotalPrice
            };
        }

        private int CreateBanner(BannerWrapper banner, int campaignId)
        {
            int bannerId = GetNewBannerId();
            _context.Banner.Add(new Banner
            {
                IdAdvertisement = bannerId,
                Name = banner.BannerName,
                Area = banner.BannerArea,
                Price = banner.BannerPrice,
                IdCampaign = campaignId
            });

            _context.SaveChanges();
            return bannerId;
        }

        private int GetNewBannerId()
        {
            return _context.Banner.Max(campaign => campaign.IdAdvertisement) + 1;
        }

        private int CreateCampaign(NewCampaignRequest request)
        {
            int campaignId = GetNewCampaignId();
            _context.Campaign.Add(new Campaign
            {
                IdCampaign = campaignId,
                StartDate = Convert.ToDateTime(request.StartDate),
                EndDate = Convert.ToDateTime(request.EndDate),
                PricePerSquareMeter = request.PricePerSquareMeter,
                FromIdBuilding = request.FromIdBuilding,
                ToIdBuilding = request.ToIdBuilding,
                IdClient = request.IdClient
            });

            _context.SaveChanges();
            return campaignId;
        }

        private int GetNewCampaignId()
        {
            return _context.Campaign.Max(campaign => campaign.IdCampaign) + 1;
        }

        private BestPriceWrapper CalculateTotalPrice(List<Building> buildings, decimal pricePerSquareMeter)
        {
            double bestPrice = 0.0;
            BannerWrapper firstBanner = new BannerWrapper();
            BannerWrapper secondBanner = new BannerWrapper();

            for (int i = 0, j = 1; i < buildings.Count && j < buildings.Count; i++, j++)
            {
                firstBanner = CreateBannersWithPrice(i, j, buildings, pricePerSquareMeter);
                secondBanner = CreateBannersWithPrice(j, buildings.Count, buildings, pricePerSquareMeter);
                if (i == 0)
                {
                    bestPrice = (double) (firstBanner.BannerPrice + secondBanner.BannerPrice);
                }
                else
                {
                    double total = (double) (firstBanner.BannerPrice + secondBanner.BannerPrice);
                    if (total < bestPrice)
                    {
                        bestPrice = total;
                    }
                }
            }

            return new BestPriceWrapper
            {
                FirstBanner = firstBanner,
                SecondBanner = secondBanner,
                TotalPrice = (decimal) bestPrice
            };
        }

        private BannerWrapper CreateBannersWithPrice(int start, int end, List<Building> buildings,
            decimal pricePerSquareMeter)
        {
            double totalPrice = 0.0;
            List<Building> buildingsCovered = new List<Building>();
            for (int i = start; i < end; i++)
            {
                var buildingPrice = buildings[i].Height * pricePerSquareMeter;
                buildingsCovered.Add(buildings[i]);
                totalPrice = totalPrice + (double) buildingPrice;
            }

            decimal highest = GetMaxBuildingHeight(buildingsCovered);
            decimal area = highest * buildingsCovered.Count;
            string bannerName = "from" + start + "to" + end + "banner";

            List<int> buildingIds = new List<int>();
            buildingsCovered.ForEach(building => buildingIds.Add(building.IdBuilding));

            return new BannerWrapper
            {
                BannerPrice = (decimal) totalPrice,
                BannerArea = area,
                BuildingCoveredIdList = buildingIds,
                BannerName = bannerName
            };
        }

        private decimal GetMaxBuildingHeight(List<Building> buildings)
        {
            return buildings.Max(building => building.Height);
        }

        private List<Building> GetAllBuildingsInBetween(int fromIdBuilding, int toIdBuilding)
        {
            int fromStreetNumber = GetStreetNumber(fromIdBuilding);
            int toStreetNumber = GetStreetNumber(toIdBuilding);
            string street = GetStreet(fromIdBuilding);
            var buildings = GetBuildingsStreetNumbersInBetween(fromStreetNumber, toStreetNumber, street);
            return buildings;
        }

        private List<Building> GetBuildingsStreetNumbersInBetween(int fromStreetNumber, int toStreetNumber,
            string street)
        {
            return _context.Building.Where(building =>
                    building.Street == street
                    && building.StreetNumber >= fromStreetNumber && building.StreetNumber <= toStreetNumber)
                .ToList();
        }

        private string GetStreet(int id)
        {
            return _context.Building.FirstOrDefault(building => building.IdBuilding == id).Street;
        }

        private int GetStreetNumber(int idBuilding)
        {
            return _context.Building.FirstOrDefault(building => building.IdBuilding == idBuilding).StreetNumber;
        }

        private bool BuildingExists(int buildingId)
        {
            return _context.Building.Any(building => building.IdBuilding == buildingId);
        }
    }
}