using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertAPI.Migrations
{
    public partial class SeedClientDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "apbd_project",
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Login", "Password", "Phone"},
                values: new object[] { 1, "jon@doe.com", "Jon", "Doe", "jondoe", "QzroB/h8qZaHF/GDwqgg6WawPHyjCjdJEqS+0VzvhV5LfKIyfM94I8W74tvo9jv6sfNRBg/N1jQAi+xG4lp5Ikg8iX39juZUi1YHwl1k/EjjLKAo21HvRWr34E5Ecz9NdRCka1AUw7KdTkBb5hCJdUrNuDe8SYTTNbre6nVncM+8VoYawaUo75vRQbrG/2+tJXWp+niz509sVsdPAdKU34LkgoX9VWwO/Cl0OO1ftdnCMoNinzXQpGiKbB3CnR7uTacxBlP4NnRSrN+TUCOPAXhQgouqnhYwfBxoYHu0b5bmUj/lL1naM/Dgn1WlDBT7sshJMY0qyKOR3rrLvAFNDQ==", "66666666" });

            migrationBuilder.InsertData(
                schema: "apbd_project",
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Login", "Password", "Phone" },
                values: new object[] { 2, "michal@scott.com", "Michal", "Scott", "dunder_mifflin", "9B0Jnhm9FHquaHgUgMAMYLpyUoSKdiN7qxRAHqjtVTyiJR/6To4x50UGUCBaMx5OPzrpI3Ly1/2ZsOHhrFuK5cB03fMWrrOroP8pwdzgtBIS54HnFWp4ykzYcBW0w7XSrZNos4xeshK7hoYiOHPACSPIeF90TAEByvOWYfkSOLgTyfQnn45OkCSfQcvtV8Sq2Z//T6Y7eGfDI4vDTxXf/kPjfNwOyP2KhhSRLSSMYyE7izWUHcvOCSnEBGjpXHcY5O8VsJ9lbceHfijCHfn98mcDbEwgY5t0n22HZPRSRpEojmQBuLBk2v9v3j67+dGfCBaDEuRlOi41pX6W1P4yGw==", "5720935" });

            migrationBuilder.InsertData(
                schema: "apbd_project",
                table: "Client",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Login", "Password", "Phone"},
                values: new object[] { 3, "Jack@Daniels.com", "Jack", "Daniels", "bourbon", "lgZDeafl+3fb5s0j5SA1tcIrk122twFPcNaysx8pY0D6naqWnhm4Ih0gorGarBM10WEk0BO8eY01domKCu0iqYdBo3Cuq9yDVEWuXDIbDNjNrwovsTbq06vLqkOCh9tuE2w0v81hNYNMn21klxikrENupUiOlDJ4PITAwpFOA5Hc6HejeYHtfDBiic2gdHr/wNzbXgDTQX0WkMhzLNhOgMOcD0MdFqMrubsmTHmco1To/LGOet/obGcjiSDWhzxW9Jfw65bO7MV5AWgR3sboq5TbiRTWeibcGU+4+K4h5APCwoXQKTN0JMmons3VnTTtO1CndDJNl5Yg7xqmnkhFPA==", "1234567878" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3);
        }
    }
}
