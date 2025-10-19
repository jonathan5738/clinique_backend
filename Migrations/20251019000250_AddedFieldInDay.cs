using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliniqueBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldInDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_days_WeekDay",
                table: "days",
                column: "WeekDay",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_days_WeekDay",
                table: "days");
        }
    }
}
