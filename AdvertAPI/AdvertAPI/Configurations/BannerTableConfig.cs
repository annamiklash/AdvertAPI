using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertAPI.Configurations
{
    public class BannerTableConfig : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(x => x.IdAdvertisement)
                .HasName("Banner_pk");

            builder.ToTable("Banner", "apbd_project");

            builder.Property(e => e.IdAdvertisement)
                .IsRequired()
                .ValueGeneratedNever();
            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(x => x.Area)
                .HasColumnType("decimal")
                .IsRequired();
            
            builder.HasOne(x => x.Campaign)
                .WithMany(x => x.Banner)
                .HasForeignKey(x => x.IdCampaign)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Campaign_Banner");
        }
    }
}