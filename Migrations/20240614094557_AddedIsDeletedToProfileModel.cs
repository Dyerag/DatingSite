using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingSite.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedToProfileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "profiles");
        }
    }
}
