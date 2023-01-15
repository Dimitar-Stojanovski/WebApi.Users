using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Users.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(name: "user_name", type: "nvarchar(max)", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "nvarchar(max)", nullable: false),
                    userstatus = table.Column<string>(name: "user_status", type: "nvarchar(max)", nullable: false),
                    createdatutc = table.Column<DateTime>(name: "created_at_utc", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "created_at_utc", "first_name", "last_name", "password", "phone_number", "user_name", "user_status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 14, 12, 25, 4, 826, DateTimeKind.Local).AddTicks(6447), "John", "Doe", "Password123", "+123 456 789", "JohnDoe123", "user" },
                    { 2, new DateTime(2023, 1, 12, 12, 25, 4, 826, DateTimeKind.Local).AddTicks(6492), "Test", "Testson", "223456", "+123 456 ", "User1234", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
