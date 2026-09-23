using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class EventDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "The ceremony will take place outdoors in the estate's beautiful garden, surrounded by flowers and old oak trees. Guests are kindly asked to arrive at least 30 minutes before the ceremony begins.");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Following the ceremony, we will continue the celebrations with drinks, dinner, speeches, and dancing in the main hall at Rosewood Estate.");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "A three-course dinner will be served in the main hall. Please let us know about any allergies or dietary requirements in your RSVP message.");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "After dinner, the newlyweds will share their first dance. The dance floor then opens to all guests, and the celebrations continue into the night.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");
        }
    }
}
