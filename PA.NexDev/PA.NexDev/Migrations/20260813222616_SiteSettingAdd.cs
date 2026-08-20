using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PA.NexDev.Migrations
{
    /// <inheritdoc />
    public partial class SiteSettingAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleUrl",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleUrl",
                table: "SiteSettings");
        }
    }
}
