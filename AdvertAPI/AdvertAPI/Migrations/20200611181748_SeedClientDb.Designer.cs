﻿// <auto-generated />
using System;
using AdvertAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdvertAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200611181748_SeedClientDb")]
    partial class SeedClientDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.5.20278.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvertAPI.Models.Banner", b =>
                {
                    b.Property<int>("IdAdvertisement")
                        .HasColumnType("int");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal");

                    b.Property<int>("IdCampaign")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.HasKey("IdAdvertisement")
                        .HasName("Banner_pk");

                    b.HasIndex("IdCampaign");

                    b.ToTable("Banner","apbd_project");
                });

            modelBuilder.Entity("AdvertAPI.Models.Building", b =>
                {
                    b.Property<int>("IdBuilding")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("IdBuilding")
                        .HasName("Building_pk");

                    b.ToTable("Building","apbd_project");
                });

            modelBuilder.Entity("AdvertAPI.Models.Campaign", b =>
                {
                    b.Property<int>("IdCampaign")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("FromIdBuilding")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasColumnType("decimal");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("ToIdBuilding")
                        .HasColumnType("int");

                    b.HasKey("IdCampaign")
                        .HasName("Campaign_pk");

                    b.HasIndex("FromIdBuilding");

                    b.HasIndex("IdClient");

                    b.HasIndex("ToIdBuilding");

                    b.ToTable("Campaign","apbd_project");
                });

            modelBuilder.Entity("AdvertAPI.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("IdClient")
                        .HasName("Client_pk");

                    b.ToTable("Client","apbd_project");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Email = "jon@doe.com",
                            FirstName = "Jon",
                            LastName = "Doe",
                            Login = "jondoe",
                            Password = "QzroB/h8qZaHF/GDwqgg6WawPHyjCjdJEqS+0VzvhV5LfKIyfM94I8W74tvo9jv6sfNRBg/N1jQAi+xG4lp5Ikg8iX39juZUi1YHwl1k/EjjLKAo21HvRWr34E5Ecz9NdRCka1AUw7KdTkBb5hCJdUrNuDe8SYTTNbre6nVncM+8VoYawaUo75vRQbrG/2+tJXWp+niz509sVsdPAdKU34LkgoX9VWwO/Cl0OO1ftdnCMoNinzXQpGiKbB3CnR7uTacxBlP4NnRSrN+TUCOPAXhQgouqnhYwfBxoYHu0b5bmUj/lL1naM/Dgn1WlDBT7sshJMY0qyKOR3rrLvAFNDQ==",
                            Phone = "66666666"
                        },
                        new
                        {
                            IdClient = 2,
                            Email = "michal@scott.com",
                            FirstName = "Michal",
                            LastName = "Scott",
                            Login = "dunder_mifflin",
                            Password = "9B0Jnhm9FHquaHgUgMAMYLpyUoSKdiN7qxRAHqjtVTyiJR/6To4x50UGUCBaMx5OPzrpI3Ly1/2ZsOHhrFuK5cB03fMWrrOroP8pwdzgtBIS54HnFWp4ykzYcBW0w7XSrZNos4xeshK7hoYiOHPACSPIeF90TAEByvOWYfkSOLgTyfQnn45OkCSfQcvtV8Sq2Z//T6Y7eGfDI4vDTxXf/kPjfNwOyP2KhhSRLSSMYyE7izWUHcvOCSnEBGjpXHcY5O8VsJ9lbceHfijCHfn98mcDbEwgY5t0n22HZPRSRpEojmQBuLBk2v9v3j67+dGfCBaDEuRlOi41pX6W1P4yGw==",
                            Phone = "5720935"
                        },
                        new
                        {
                            IdClient = 3,
                            Email = "Jack@Daniels.com",
                            FirstName = "Jack",
                            LastName = "Daniels",
                            Login = "bourbon",
                            Password = "lgZDeafl+3fb5s0j5SA1tcIrk122twFPcNaysx8pY0D6naqWnhm4Ih0gorGarBM10WEk0BO8eY01domKCu0iqYdBo3Cuq9yDVEWuXDIbDNjNrwovsTbq06vLqkOCh9tuE2w0v81hNYNMn21klxikrENupUiOlDJ4PITAwpFOA5Hc6HejeYHtfDBiic2gdHr/wNzbXgDTQX0WkMhzLNhOgMOcD0MdFqMrubsmTHmco1To/LGOet/obGcjiSDWhzxW9Jfw65bO7MV5AWgR3sboq5TbiRTWeibcGU+4+K4h5APCwoXQKTN0JMmons3VnTTtO1CndDJNl5Yg7xqmnkhFPA==",
                            Phone = "1234567878"
                        });
                });

            modelBuilder.Entity("AdvertAPI.Models.Banner", b =>
                {
                    b.HasOne("AdvertAPI.Models.Campaign", "Campaign")
                        .WithMany("Banner")
                        .HasForeignKey("IdCampaign")
                        .HasConstraintName("Campaign_Banner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvertAPI.Models.Campaign", b =>
                {
                    b.HasOne("AdvertAPI.Models.Building", "FromBuilding")
                        .WithMany("CampaignFrom")
                        .HasForeignKey("FromIdBuilding")
                        .HasConstraintName("FromBuilding_Campaign")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AdvertAPI.Models.Client", "Client")
                        .WithMany("Campaign")
                        .HasForeignKey("IdClient")
                        .HasConstraintName("Client_Campaign")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AdvertAPI.Models.Building", "ToBuilding")
                        .WithMany("CampaignTo")
                        .HasForeignKey("ToIdBuilding")
                        .HasConstraintName("ToBuilding_Campaign")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
