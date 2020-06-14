using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertAPI.Migrations
{
    public partial class SeedBuildingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "apbd_project",
                table: "Building",
                columns: new[] { "IdBuilding", "City", "Height", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Manhattan", 54.6m, "Wall", 33 },
                    { 2, "Manhattan", 54.6m, "Wall", 34 },
                    { 3, "Manhattan", 15.44m, "Astor Place", 1 },
                    { 4, "Manhattan", 15.44m, "Astor Place", 3 },
                    { 5, "Manhattan", 100.4m, "Bleecker", 68 },
                    { 6, "Manhattan", 100.4m, "Bleecker", 69 },
                    { 7, "Brooklyn", 28.5m, "Flatbush Ave", 80 },
                    { 8, "Brooklyn", 28.5m, "Flatbush Ave", 81 }
                });

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: "weiIi7CX75r7W29pKEiNm6gcq++mpv6YJWHjSEDvN8Nm2FWPZg3/UzZ+n00vJosEqwrkgxlfyzrwW12KfZHQRBo5kmjiBjoyXBGbwm0B3wfg6vaYQPsiKX8DTsLFl/uuOnqz6oxDXpxN/LqIVv9XJQKh99TyrYRJXkA1dvnLLkEvsXqAX+QHRTjGJaI2Vaxso3VZFyz+kHarqM7NPkAF5r5njPsFzub1qmVIGZB5T28LzaKtJLoNI/aZ3eOyU6op0t408Ymyang4AzIOVUc21UkLAuTyhumx3kToqY46v8knFDRVfMpJeOiR/UF3gSEBZjUZLmiFXsm0awsifcpY1g==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2,
                column: "Password",
                value: "gS4JDVLRzf1L58n35pHNggFpYvihkXGgDS25Hth7N2e7peKvpcAvHBq8tg6zFvvtEb3Vmp+euc8MXTBNy3fh8D7ZYODYGBNtrb6K7RlPDvWYGGaiqH4Al8rEZnM7icqzkgCagvOE142MdY0DlmVfaavcQlof1k3ixOGbCpRr/ixm0rkL+D3Ej3b7zVY5O0AcrMLOH4u3laqOVa4Ritoigfy7Awu0DtvDxp70EcvVfYcv5/wZUTXGwoTFJPRqOvm3fR1Sy4EhKAYF3Kqkr5NgI84Tb2uP5JVJ3b1LFwQTQ5Xdxd8/FPNXlCIOwGqkHqj2EXcMVlO32fHhTpP7BDnpGQ==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3,
                column: "Password",
                value: "LHt/u342UFasHQsmauomJKA073IZ+fwbPOEADARc1airImbmTa6l/kPbRvCiKVcLox2HsxOlUJv/ciVd5dGo5qNrQVSDuFOLOeEbrcOGbEqu2Be4V1ZG/nl/LpeuCXcyHklSvho0B3SAQdDZbokz2yi8D6YZPzlnZ9oupUSsbcT6cIY1Y4CQMTK+EEFcbfDbI3x8FvcXKSkCNSkMqOO4QU9ISyrMGkeAYdwl1itmzSN0/JPRrdTF8pycdM1k2PUtDSM2vgt5WXh4CAz3cIEfA/CzhMeWZ4skZZLoIn+DUjD6sQY4uBbeynReS6XprKIDaJYjn2rU3ddPVZGR0iQVTg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Building",
                keyColumn: "IdBuilding",
                keyValue: 8);

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: "QzroB/h8qZaHF/GDwqgg6WawPHyjCjdJEqS+0VzvhV5LfKIyfM94I8W74tvo9jv6sfNRBg/N1jQAi+xG4lp5Ikg8iX39juZUi1YHwl1k/EjjLKAo21HvRWr34E5Ecz9NdRCka1AUw7KdTkBb5hCJdUrNuDe8SYTTNbre6nVncM+8VoYawaUo75vRQbrG/2+tJXWp+niz509sVsdPAdKU34LkgoX9VWwO/Cl0OO1ftdnCMoNinzXQpGiKbB3CnR7uTacxBlP4NnRSrN+TUCOPAXhQgouqnhYwfBxoYHu0b5bmUj/lL1naM/Dgn1WlDBT7sshJMY0qyKOR3rrLvAFNDQ==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2,
                column: "Password",
                value: "9B0Jnhm9FHquaHgUgMAMYLpyUoSKdiN7qxRAHqjtVTyiJR/6To4x50UGUCBaMx5OPzrpI3Ly1/2ZsOHhrFuK5cB03fMWrrOroP8pwdzgtBIS54HnFWp4ykzYcBW0w7XSrZNos4xeshK7hoYiOHPACSPIeF90TAEByvOWYfkSOLgTyfQnn45OkCSfQcvtV8Sq2Z//T6Y7eGfDI4vDTxXf/kPjfNwOyP2KhhSRLSSMYyE7izWUHcvOCSnEBGjpXHcY5O8VsJ9lbceHfijCHfn98mcDbEwgY5t0n22HZPRSRpEojmQBuLBk2v9v3j67+dGfCBaDEuRlOi41pX6W1P4yGw==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3,
                column: "Password",
                value: "lgZDeafl+3fb5s0j5SA1tcIrk122twFPcNaysx8pY0D6naqWnhm4Ih0gorGarBM10WEk0BO8eY01domKCu0iqYdBo3Cuq9yDVEWuXDIbDNjNrwovsTbq06vLqkOCh9tuE2w0v81hNYNMn21klxikrENupUiOlDJ4PITAwpFOA5Hc6HejeYHtfDBiic2gdHr/wNzbXgDTQX0WkMhzLNhOgMOcD0MdFqMrubsmTHmco1To/LGOet/obGcjiSDWhzxW9Jfw65bO7MV5AWgR3sboq5TbiRTWeibcGU+4+K4h5APCwoXQKTN0JMmons3VnTTtO1CndDJNl5Yg7xqmnkhFPA==");
        }
    }
}
