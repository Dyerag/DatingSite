using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingSite.Migrations
{
    /// <inheritdoc />
    public partial class RemovedProfileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileName",
                table: "profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileName",
                table: "profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
