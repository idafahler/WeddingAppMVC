using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class WeddingInfoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeddingInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WelcomeMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    WebsiteDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ClosingMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeddingInfos",
                columns: new[] { "Id", "ClosingMessage", "Contact", "Description", "Title", "WebsiteDescription", "WelcomeMessage" },
                values: new object[] { 1, "We can't wait to celebrate with you!", "alice.bob@example.com", "We’re so happy to have you here! Welcome to the official wedding website of Alice & Bob. ", "Alice & Bob's forever begins", "Here you can find information about the wedding and RSVP. If you need to contact us, contact our email below.", "Welcome to our wedding!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeddingInfos");
        }
    }
}
