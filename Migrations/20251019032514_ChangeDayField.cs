using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliniqueBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDayField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_days_DayId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_DayId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "schedules");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "schedules",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "schedules");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_DayId",
                table: "schedules",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_days_DayId",
                table: "schedules",
                column: "DayId",
                principalTable: "days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
