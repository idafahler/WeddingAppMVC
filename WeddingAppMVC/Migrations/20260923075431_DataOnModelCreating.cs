using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeddingAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class DataOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Attendance",
                table: "Guests",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Address", "EndTime", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, "18 Willow Lane, Hampshire, England", null, "Rosewood Estate", new DateTime(2027, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), "The ceremony" },
                    { 2, "18 Willow Lane, Hampshire, England", null, "Rosewood Estate", new DateTime(2027, 6, 20, 16, 30, 0, 0, DateTimeKind.Unspecified), "The reception" },
                    { 3, "18 Willow Lane, Hampshire, England", null, "Rosewood Estate", new DateTime(2027, 6, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Dinner" },
                    { 4, "18 Willow Lane, Hampshire, England", null, "Rosewood Estate", new DateTime(2027, 6, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), "First dance" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Attendance", "Email", "FirstName", "LastName", "Message", "NumberOfAttendants", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, null, "emma.andersson@example.com", "Emma", "Andersson", null, 1, "070 123 45 67", new DateTime(2026, 9, 1, 10, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "oscar.lindqvist@example.com", "Oscar", "Lindqvist", null, 1, "073 234 56 78", new DateTime(2026, 9, 2, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "sara.berg@example.com", "Sara", "Berg", null, 1, "076 345 67 89", new DateTime(2026, 9, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, true, "johan.nilsson@example.com", "Johan", "Nilsson", "Looking forward to it!", 2, "070 456 78 90", new DateTime(2026, 9, 4, 18, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 5, true, "lina.karlsson@example.com", "Lina", "Karlsson", "I'm vegetarian.", 1, "072 567 89 01", new DateTime(2026, 9, 5, 12, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 6, true, "erik.svensson@example.com", "Erik", "Svensson", "Bringing the kids, hope that's fine.", 4, "070 678 90 12", new DateTime(2026, 9, 6, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, false, "maja.holm@example.com", "Maja", "Holm", "Sadly can't make it, congratulations!", 1, "073 789 01 23", new DateTime(2026, 9, 7, 8, 20, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<bool>(
                name: "Attendance",
                table: "Guests",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
