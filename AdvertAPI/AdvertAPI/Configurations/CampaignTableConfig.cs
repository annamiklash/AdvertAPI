using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertAPI.Configurations
{
    public class CampaignTableConfig : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(x => x.IdCampaign)
                .HasName("Campaign_pk");

            builder.ToTable("Campaign", "apbd_project");

            builder.Property(e => e.IdCampaign)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.StartDate)
                .HasColumnType("date");

            builder.Property(x => x.EndDate)
                .HasColumnType("date");
            
            builder.Property(x => x.PricePerSquareMeter)
                .HasColumnType("decimal")
                .IsRequired();

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Campaign)
                .HasForeignKey(x => x.IdClient)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired()
                .HasConstraintName("Client_Campaign");

            builder.HasOne(x => x.FromBuilding)
                .WithMany(x => x.CampaignFrom)
                .HasForeignKey(x => x.FromIdBuilding)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired()
                .HasConstraintName("FromBuilding_Campaign");

            builder.HasOne(x => x.ToBuilding)
                .WithMany(x => x.CampaignTo)
                .HasForeignKey(x => x.ToIdBuilding)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired()
                .HasConstraintName("ToBuilding_Campaign");

        }
    }
}