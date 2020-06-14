using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertAPI.Migrations
{
    public partial class SeedCampaignDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "apbd_project",
                table: "Campaign",
                columns: new[] { "IdCampaign", "EndDate", "FromIdBuilding", "IdClient", "PricePerSquareMeter", "StartDate", "ToIdBuilding" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 120m, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 200m, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, new DateTime(2020, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 170m, new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 4, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 160m, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1,
                column: "Password",
                value: "RRgXFZLyFhlyMUpyJPDWjVlzn6mnF4fh4xqpAuHsBpV+weSaVPZkFPpBndQjX9XZZnUnbkhFcb0BrtfWTj7GLtIB78u81YZkEeKwoyQN736zhLiftS+XSRyeJqzN5h4swEOvSNkGbeHa4LcpTpXTJVi/mJPY/jjQOFjEReFCf7xvokqplw7qhFJU7Fi0SoO9lH+/Z3acjdwsTj604u16pr7doeKsrYio9EZyRyT5LkOKZPikxVg4Qh7uTw6FqvoovkaKVVvOCWHBHxe3d/I3zykIUx6wnYYhwc1alYQMyAS6BYD68a7K3dd1XCw42P/IeRt34yerAs6MxbwwHxTYwg==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2,
                column: "Password",
                value: "zT6+ffSnc0Znyr1SVCM5HqBHmFYTx4ys5MY6RBNkhSKM4cf8upZnj4XLzLsSNEb5lIm+L7Z/RDrHwl2NmwrMnASDACoT0GSr8UWol/s+OLEPxNkpOiyKSBYhy24G8Dc3OG0PS/3CP+7IVunL0RK6iVQBLoWuQU4jS0FWfyn+j70FS0ECcyWYMj0c13VBpH4ntOtfKMiNVAXHA0voWblshgqdLHNEfCJfVIqvo4UmtlPlSJ17hWHd7cwgM5QtDInCKOBlh/9PzHNmPCkFvH6z9O87P1U+BWX8+LhaKRqvyMXYpLr7K0hXWA8vWVJQkIRCtxgaDySTp2Pqu8IQHOT2MA==");

            migrationBuilder.UpdateData(
                schema: "apbd_project",
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3,
                column: "Password",
                value: "jMmKpRFuPyG8UVQHgW+cEGkeQ3ZtpsCMv5AsJqr8odAyCd5e4ZlgSi659UaV84JkshSOUByolpGws8wbyH02lN3ncNg+tMwkcN2CZS/+yNmp7eSgRjrK/8MJHR2a5s1+ua8NHdVaIKnStGCNwicRtpmijD33iqlg5rnYFJFANyZ6PSJ/ebfeo3ZyZxJR+o9AzEm5GLuKhDleCLDZ4XjAl56e7kOr2h6vIOv7XShSlroBlkU2dRrCG4hQU+Mbk0RYGr1J9LlCOYj2QSR2+C7d7s70fe6NHbX2NLIjHs9WerzcX7xiSjPQfU0XYtqulIr0srUUbGYlHtds1m4iGoy2QQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Campaign",
                keyColumn: "IdCampaign",
                keyValue: 4);

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
    }
}
