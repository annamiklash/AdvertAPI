using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertAPI.Configurations
{
    public class AccessTokenTableConfig : IEntityTypeConfiguration<AccessToken>
    {
        public void Configure(EntityTypeBuilder<AccessToken> builder)
        {
            builder.HasKey(x => x.IdAccessToken)
                .HasName("AccessToken_pk");

            builder.ToTable("AccessToken", "apbd_project");

            builder.Property(e => e.IdAccessToken)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.IssueDateTime)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.ExpirationDateTime)
                .IsRequired()
                .HasColumnType("date");

            // builder.HasOne(x => x.Client)
            //     .WithOne(x => x.AccessToken)
            //     .HasForeignKey<Client>(x => x.IdClient);
        }
    }
}