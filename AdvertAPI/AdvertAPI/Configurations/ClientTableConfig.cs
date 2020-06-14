using AdvertAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertAPI.Configurations
{
    public class ClientTableConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.IdClient)
                .HasName("Client_pk");

            builder.ToTable("Client", "apbd_project");
                
            builder.Property(e => e.IdClient)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(x => x.Salt)
                .HasMaxLength(200);

            builder.HasMany(d => d.Campaign)
                .WithOne(x => x.Client);

            builder.HasOne(x => x.AccessToken)
                .WithOne(x => x.Client)
                .HasForeignKey<AccessToken>(x => x.IdClient);
            
            builder.HasOne(x => x.RefreshToken)
                .WithOne(x => x.Client)
                .HasForeignKey<RefreshToken>(x => x.IdClient);

        }
    }
}