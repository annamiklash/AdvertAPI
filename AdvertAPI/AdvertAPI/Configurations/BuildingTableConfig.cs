using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertAPI.Configurations
{
    public class BuildingTableConfig : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(x => x.IdBuilding)
                .HasName("Building_pk");

            builder.ToTable("Building", "apbd_project");
                
            builder.Property(e => e.IdBuilding)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StreetNumber)
                .IsRequired();
            
            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Height)
                .HasColumnType("decimal")
                .IsRequired();

            builder.HasMany(d => d.CampaignFrom)
                .WithOne(x => x.FromBuilding);
            
            builder.HasMany(d => d.CampaignTo)
                .WithOne(x => x.ToBuilding);

        }
    }
}