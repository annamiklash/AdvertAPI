using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertAPI.Migrations
{
    public partial class AddTokensAndSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                schema: "apbd_project",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "apbd_project",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                schema: "apbd_project",
                table: "Client",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessToken",
                schema: "apbd_project",
                columns: table => new
                {
                    IdAccessToken = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExpirationDateTime = table.Column<DateTime>(type: "date", nullable: false),
                    IssueDateTime = table.Column<DateTime>(type: "date", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AccessToken_pk", x => x.IdAccessToken);
                    table.ForeignKey(
                        name: "FK_AccessToken_Client_IdClient",
                        column: x => x.IdClient,
                        principalSchema: "apbd_project",
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "apbd_project",
                columns: table => new
                {
                    IdRefreshToken = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IssueDateTime = table.Column<DateTime>(type: "date", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RefreshToken_pk", x => x.IdRefreshToken);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Client_IdClient",
                        column: x => x.IdClient,
                        principalSchema: "apbd_project",
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: "8NlfdeHbQNTUHu9iI2ry1G2n8kCkvAmBVXM7KbbxfiIjuI8nL+Agn/2V6aoP2y3+SzhFjm7gmX/hklwIbPEob0m2nsCdvZ9USOat3TzEQlZ+6+WIweFGV18SwxAHnDJoqGxGQiN8sszvbou0Ffkox/FRgWyvW5HUUA/L57u/Lx1I0WEDC7NrxK9x25L67m1+ENSyTJfkSKUC/A1EDbH8yqJBojlK0SeGX2UwP1VwrD3tejNJt3hfVQPvaqcDjuw0EVqvqC/fXrXJQ8obJyVFLj2v1AcZgrzHTJ0L5MHvDt2ItnkjKWqYcCPF1ruAxxDif1G1pCd/+o8UTHFXcTrT6A==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2,
                column: "Password",
                value: "Vp/A53X+PQqKwcx1X7CG5XSzDfTLXLptAZ44+8ABS5J7r0JBEozdxg0VFPj09YgbyoEtX391ACoGg8m/Wj3sge8yZWmC/iKsBbP24sPJy1ojP9sI48ngn62t5Ek2uxExM+RI3xh+NHAi+xVrBgge/1hnaE1pARuX5WP1Z8EECTXA87UsVImoB3lP4Te/wUwA6LbRqNXU45+UrZaWt/OPlHcmjhgcPbGc+oV5ezEw0TFiA2yXHlT67lArEViY66nUf1vrl5mCosITfpAbgl73/OEJ3ExwUP4x97QcI654zAI2EBFVf9kGAMHfrqwOUW20bVlW24Bes0HXjMz0a3kqvg==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3,
                column: "Password",
                value: "EdFNDpl6W4NrpGVi7X5iHqq6Squ7Nr5RbRYV3JrjLeXc65J0nGLml/kyudfAwppu+igiaeWoYc6VyiPIuGagWj0H6Ozt4vLH0/KUsLM0c2LxxT7iI3e6qdPZ2YkTYLN4a6x3qMfOh3BB4jvKJ3A/9MYERuZBu8jRnU5iZw/BG2HDI1e8B8yvkEVXUzMfDXU3FHlnbDXg+Gww6R35TsSzcd7lGIexhF2lgM5ySaCKn3kpF2qpgWXpwyj9waXdEobwoEW/0anrvuQYa9K3otpzcFwXLq/d0+7Rd8fgdq+8C/3wdS9kHhmW5AiQwsIrv67WihfcmCE1UIKXv85gwPGlEw==");

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_IdClient",
                schema: "apbd_project",
                table: "AccessToken",
                column: "IdClient",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_IdClient",
                schema: "apbd_project",
                table: "RefreshToken",
                column: "IdClient",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken",
                schema: "apbd_project");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "apbd_project");

            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "apbd_project",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                schema: "apbd_project",
                table: "Client",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "apbd_project",
                table: "Client",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: "DR6UFyuKs8ybA9UUb4dF4h2tqf+u2uWExaKl7HTbhgXvUFOvwfHt4Cpbzv8tTohMI6uMSTddyYjYv2MugeOSjc0Y3zr8Z1ujSOAn3b+wjzzWUIzTaAmQ4tzBvPmotqrFoeuE/w+FLu9m2H3xLTPgGpsyrtPr9Nl9mqgrILnvvLsWBybDBDzH//SBiqUFMRuI0SIdZO/jbO4m425HRGBEg8r7+CslFdxKcMGNEerTB3wXu1dTLmSEPV6ieIJPhqtfoKqo/0wmP6Cf344atD5MZfa7E2zl3JafX+DwsgdcYfeV0y34sTsBW5WaJLSmpSLNuS0wbXHBk82PefQKyZPN1A==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2,
                column: "Password",
                value: "UigqOl6oPqUlZFUqSvgS/gWNeY85VBlOH6hl/t7O1mKK4jr8/sH2Ojbo4LS05EnL4iReoMIlbMsQsSvmUnpoDpOSWsvCuBSqfs5LqRBk88MigvgOXIwvtM+GyZ/N5FT09JhJOLKyLROGk0yfOq5wPSdsMOzEAOBPw6qo+eJumDXkVCRZYQsanLlnlPYa6ANM//vIfMgXRmV2N2kbYOjDdVRJJpNaF+AStci0nDWTwdGlT001H7I6K+T/2zA6DcZjL55YiIVYtsz5IvNNTvyUoojC/PtCe4DibW2dOrFr+EoMtIj+3IF9kwWPC7sGcS1CR8jq6bBOaORcHzBAqp3J+A==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3,
                column: "Password",
                value: "jvd+Zfkkw2XJE/5/sCstVjiWgKyXXotW4OkUtiI9pJ+2h1p/qLIVPRldkfG1JF4nISLmQ7MDaRoMudmsWGN9NfBJiFw0qjaSjlBFAeWpVJVw7UFckJ7Pkqmqn53S2AqnmAJctF2Hq1EGYmvhzwo8Ii2XQOk1unkeXWh5wEsW/ulevPRDIxp6l1kfQB//LiubwS141ddGuwLMLweIZhPfAkDfb3fuNl4pNDT74N5K/OPRdCSFqGPpDSCns02A8G+dWHNt51vzEW8pA8lyEh/QgDhMmP4q/FsKFgEZ3SaLz4T/5GQJvYXKHjo6/vc5nmdSNCG6WbdtxMHutFj0vB0euA==");
        }
    }
}
