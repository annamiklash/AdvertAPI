using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertAPI.Configurations
{
    public class RefreshTokenTableConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.IdRefreshToken)
                .HasName("RefreshToken_pk");

            builder.ToTable("RefreshToken", "apbd_project");

            builder.Property(e => e.IdRefreshToken)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.IssueDateTime)
                .IsRequired()
                .HasColumnType("date");
            
        }
    }
}