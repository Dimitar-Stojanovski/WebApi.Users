using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Users.Migrations
{
    /// <inheritdoc />
    public partial class AddedUtcInBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at_utc",
                value: new DateTime(2023, 1, 29, 10, 20, 28, 857, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at_utc",
                value: new DateTime(2023, 1, 27, 10, 20, 28, 857, DateTimeKind.Local).AddTicks(4400));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at_utc",
                value: new DateTime(2023, 1, 14, 12, 25, 4, 826, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at_utc",
                value: new DateTime(2023, 1, 12, 12, 25, 4, 826, DateTimeKind.Local).AddTicks(6492));
        }
    }
}
