using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class GuestHasResponded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasResponded",
                table: "Guests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1,
                column: "HasResponded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2,
                column: "HasResponded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3,
                column: "HasResponded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 4,
                column: "HasResponded",
                value: true);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 5,
                column: "HasResponded",
                value: true);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 6,
                column: "HasResponded",
                value: true);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 7,
                column: "HasResponded",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasResponded",
                table: "Guests");
        }
    }
}
