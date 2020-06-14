using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertAPI.Migrations
{
    public partial class SeedBannerDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "apbd_project",
                table: "Banner",
                columns: new[] { "IdAdvertisement", "Area", "IdCampaign", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 7m, 1, "Name_1", 600m },
                    { 2, 4m, 2, "Name_2", 300m },
                    { 3, 5m, 4, "Name_3", 500m },
                    { 4, 3m, 3, "Name_4", 360m }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Banner",
                keyColumn: "IdAdvertisement",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Banner",
                keyColumn: "IdAdvertisement",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Banner",
                keyColumn: "IdAdvertisement",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "apbd_project",
                table: "Banner",
                keyColumn: "IdAdvertisement",
                keyValue: 4);

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
    }
}
