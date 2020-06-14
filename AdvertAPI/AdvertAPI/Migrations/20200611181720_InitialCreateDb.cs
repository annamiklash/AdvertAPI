using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertAPI.Migrations
{
    public partial class InitialCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "apbd_project");

            migrationBuilder.CreateTable(
                name: "Building",
                schema: "apbd_project",
                columns: table => new
                {
                    IdBuilding = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Height = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Building_pk", x => x.IdBuilding);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "apbd_project",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_pk", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                schema: "apbd_project",
                columns: table => new
                {
                    IdCampaign = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    PricePerSquareMeter = table.Column<decimal>(type: "decimal", nullable: false),
                    FromIdBuilding = table.Column<int>(type: "int", nullable: false),
                    ToIdBuilding = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Campaign_pk", x => x.IdCampaign);
                    table.ForeignKey(
                        name: "Client_Campaign",
                        column: x => x.IdClient,
                        principalSchema: "apbd_project",
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FromBuilding_Campaign",
                        column: x => x.FromIdBuilding,
                        principalSchema: "apbd_project",
                        principalTable: "Building",
                        principalColumn: "IdBuilding");
                    table.ForeignKey(
                        name: "ToBuilding_Campaign",
                        column: x => x.ToIdBuilding,
                        principalSchema: "apbd_project",
                        principalTable: "Building",
                        principalColumn: "IdBuilding");
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                schema: "apbd_project",
                columns: table => new
                {
                    IdAdvertisement = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    Area = table.Column<decimal>(type: "decimal", nullable: false),
                    IdCampaign = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Banner_pk", x => x.IdAdvertisement);
                    table.ForeignKey(
                        name: "Campaign_Banner",
                        column: x => x.IdCampaign,
                        principalSchema: "apbd_project",
                        principalTable: "Campaign",
                        principalColumn: "IdCampaign",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banner_IdCampaign",
                schema: "apbd_project",
                table: "Banner",
                column: "IdCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_FromIdBuilding",
                schema: "apbd_project",
                table: "Campaign",
                column: "FromIdBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_IdClient",
                schema: "apbd_project",
                table: "Campaign",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ToIdBuilding",
                schema: "apbd_project",
                table: "Campaign",
                column: "ToIdBuilding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner",
                schema: "apbd_project");

            migrationBuilder.DropTable(
                name: "Campaign",
                schema: "apbd_project");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "apbd_project");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "apbd_project");
        }
    }
}
