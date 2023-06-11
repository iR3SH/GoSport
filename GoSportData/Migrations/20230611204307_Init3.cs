using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoSportData.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$lQeRsMj0fUuVKv9L/3zpmOY2uq8mzZF09rJOKjSpiGbGHXOEgWgwK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$TA7L6/3tOdZ8kMud.LaB..ZFzMMR0JFodJhARfFwbaDD0lNw73mGW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$NUAI.uLu7TcbV8u4n.RXDOPVFtUW.6m2rVsDddw/xMeO19x9zkbKm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$3x5ZJmQ3XytPn3P5niQNjeovMEPHAAMkdWudKelVn0Vorp1aPcZ4G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$CyItoK8xixKUI0zv2ZeG6ueY0qkCsKWCsarN.LFGM3OlWtjli53pC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$7nCvIMUq7zQiKjCNu5K/7efx99r2.XhLK7gP.1AsOvH2xpabvX3lG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$y/8Rx6t8Wr2j0MooQ3VOzuFpMhpts5RbRFgIShzuUjqgZTLy6yS/u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$JJRVasnTIf9F1Kkd6nrBNeizUnthZqpL7uxweTo/Klf2SQuEVJ3sy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Iw1VQ8qH4KywviV64Z70zOBfJZ67QkvBhFdUHqsQM74HG36A1M8PG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$ls898/CxNXvbxF/6NNic2u93gLVHpmzv4kqh.xgpB/DjWy4sDGeNu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$Q58/olYd5Gpr7xkK6.eBZeAT5IPVvGP6XlNeB.p5.Udyb9kGjtyh6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$Mwq.an2qHpFH5bn3q/wp0Od5aWsMpnoF4oJFXP95vH2DuhBtZ9xXS");
        }
    }
}
