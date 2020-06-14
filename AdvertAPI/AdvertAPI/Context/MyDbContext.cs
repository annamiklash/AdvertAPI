using AdvertAPI.Configurations;
using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertAPI.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<AccessToken> AccessToken { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public MyDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientTableConfig());
            modelBuilder.ApplyConfiguration(new BuildingTableConfig());
            modelBuilder.ApplyConfiguration(new CampaignTableConfig());
            modelBuilder.ApplyConfiguration(new BannerTableConfig());
            modelBuilder.ApplyConfiguration(new AccessTokenTableConfig());
            modelBuilder.ApplyConfiguration(new RefreshTokenTableConfig());
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}