using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PA.NexDev.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "SiteSettings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
