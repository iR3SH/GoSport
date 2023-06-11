using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoSportData.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOver",
                table: "Tournaments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOver",
                table: "Tournaments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$0vslohBv95lMr7X23XKY9epSjrTTPn23Lzqb6hREr66YMbIL4QP4i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$88O3omIUnFp3VyD7OO.VReSmR2ptXFMNPqoTDg/SFjUj6qrKzX9Ne");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$KX1LdQMvOkNPWMYdr8ZW.uABYWmdaA.AoMOCbf2b4Mbqq1P09w1y.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$8YxsjYtmkJR/FY.90cHR8eW5XaEdr/8kXISyXs1I1t9Z6y6YJ4DQu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$isbinYifFHlGV9ZnF8jLHu/StgaWQFnWP23e8wSBOySKfJB9wr4Qq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$Q9FhN8Z2r0lPndWx8VFToeJp.9VmFzCinkQ/vRwY6KwqoDBEgmjxq");
        }
    }
}
