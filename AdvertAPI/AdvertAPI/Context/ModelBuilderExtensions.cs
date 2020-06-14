using System;
using System.Collections.Generic;
using System.Globalization;
using AdvertAPI.Generators;
using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertAPI.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var clients = GenerateClients();
            var buildings = GenerateBuildings();
            var campaigns = GenerateCampaigns();
            var banners = GenerateBanners();

            SeedClient(clients, modelBuilder);
            SeedBuilding(buildings, modelBuilder);
            SeedCampaign(campaigns, modelBuilder);
            SeedBanner(banners, modelBuilder);
        }

        private static void SeedClient(List<Client> clients, ModelBuilder modelBuilder)
        {
            foreach (var client in clients)
            {
                modelBuilder
                    .Entity<Client>()
                    .HasData(client);
            }
        }

        private static void SeedBuilding(List<Building> buildings, ModelBuilder modelBuilder)
        {
            foreach (var building in buildings)
            {
                modelBuilder
                    .Entity<Building>()
                    .HasData(building);
            }
        }

        private static void SeedCampaign(List<Campaign> campaigns, ModelBuilder modelBuilder)
        {
            foreach (var campaign in campaigns)
            {
                modelBuilder
                    .Entity<Campaign>()
                    .HasData(campaign);
            }
        }

        private static void SeedBanner(List<Banner> banners, ModelBuilder modelBuilder)
        {
            foreach (var banner in banners)
            {
                modelBuilder
                    .Entity<Banner>()
                    .HasData(banner);
            }
        }

        private static List<Banner> GenerateBanners()
        {
            return new List<Banner>
            {
                new Banner
                {
                    IdAdvertisement = 1,
                    Name = "Name_1",
                    Price = 600,
                    Area = 7,
                    IdCampaign = 1
                },
                new Banner
                {
                    IdAdvertisement = 2,
                    Name = "Name_2",
                    Price = 300,
                    Area = 4,
                    IdCampaign = 2
                },
                new Banner
                {
                    IdAdvertisement = 3,
                    Name = "Name_3",
                    Price = 500,
                    Area = 5,
                    IdCampaign = 4
                },
                new Banner
                {
                    IdAdvertisement = 4,
                    Name = "Name_4",
                    Price = 360,
                    Area = 3,
                    IdCampaign = 3
                }
            };
        }

        private static List<Campaign> GenerateCampaigns()
        {
            return new List<Campaign>
            {
                new Campaign
                {
                    IdCampaign = 1,
                    StartDate = DateTime.ParseExact("20-03-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("20-08-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    PricePerSquareMeter = 120,
                    IdClient = 1,
                    FromIdBuilding = 1,
                    ToIdBuilding = 2
                },
                new Campaign
                {
                    IdCampaign = 2,
                    StartDate = DateTime.ParseExact("15-04-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("15-10-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    PricePerSquareMeter = 200,
                    IdClient = 2,
                    FromIdBuilding = 3,
                    ToIdBuilding = 4
                },
                new Campaign
                {
                    IdCampaign = 3,
                    StartDate = DateTime.ParseExact("09-06-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06-12-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    PricePerSquareMeter = 170,
                    IdClient = 3,
                    FromIdBuilding = 5,
                    ToIdBuilding = 6
                },
                new Campaign
                {
                    IdCampaign = 4,
                    StartDate = DateTime.ParseExact("01-07-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("01-10-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    PricePerSquareMeter = 160,
                    IdClient = 2,
                    FromIdBuilding = 7,
                    ToIdBuilding = 8
                }
            };
        }

        private static List<Building> GenerateBuildings()
        {
            return new List<Building>
            {
                new Building
                {
                    IdBuilding = 1,
                    Street = "Wall",
                    StreetNumber = 33,
                    City = "Manhattan",
                    Height = new decimal(54.6)
                },
                new Building
                {
                    IdBuilding = 2,
                    Street = "Wall",
                    StreetNumber = 34,
                    City = "Manhattan",
                    Height = new decimal(54.6)
                },
                new Building
                {
                    IdBuilding = 3,
                    Street = "Astor Place",
                    StreetNumber = 1,
                    City = "Manhattan",
                    Height = new decimal(15.44)
                },
                new Building
                {
                    IdBuilding = 4,
                    Street = "Astor Place",
                    StreetNumber = 3,
                    City = "Manhattan",
                    Height = new decimal(15.44)
                },
                new Building
                {
                    IdBuilding = 5,
                    Street = "Bleecker",
                    StreetNumber = 68,
                    City = "Manhattan",
                    Height = new decimal(100.4)
                },
                new Building
                {
                    IdBuilding = 6,
                    Street = "Bleecker",
                    StreetNumber = 69,
                    City = "Manhattan",
                    Height = new decimal(100.4)
                },
                new Building
                {
                    IdBuilding = 7,
                    Street = "Flatbush Ave",
                    StreetNumber = 80,
                    City = "Brooklyn",
                    Height = new decimal(28.5)
                },
                new Building
                {
                    IdBuilding = 8,
                    Street = "Flatbush Ave",
                    StreetNumber = 81,
                    City = "Brooklyn",
                    Height = new decimal(28.5)
                }
            };
        }

        private static List<Client> GenerateClients()
        {
            return new List<Client>
            {
                new Client
                {
                    IdClient = 1,
                    FirstName = "Jon",
                    LastName = "Doe",
                    Email = "jon@doe.com",
                    Phone = "66666666",
                    Login = "jondoe",
                    Password = HashSaltGenerator.GenerateSaltedHash("aaaaaaaa").Hash
                },
                new Client
                {
                    IdClient = 2,
                    FirstName = "Michal",
                    LastName = "Scott",
                    Email = "michal@scott.com",
                    Phone = "5720935",
                    Login = "dunder_mifflin",
                    Password = HashSaltGenerator.GenerateSaltedHash("dunder_mifflin").Hash
                },
                new Client
                {
                    IdClient = 3,
                    FirstName = "Jack",
                    LastName = "Daniels",
                    Email = "Jack@Daniels.com",
                    Phone = "1234567878",
                    Login = "bourbon",
                    Password = HashSaltGenerator.GenerateSaltedHash("jack").Hash
                }
            };
        }
    }
}