using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Attendance",
                table: "Guests",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Attendance",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Attendance",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Attendance",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Attendance",
                table: "Guests",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Attendance",
                value: null);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Attendance",
                value: null);

            migrationBuilder.UpdateData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Attendance",
                value: null);
        }
    }
}
