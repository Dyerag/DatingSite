using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatingSite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Zipcode);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Cities_Zipcode",
                        column: x => x.Zipcode,
                        principalTable: "Cities",
                        principalColumn: "Zipcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_profiles_Accounts_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    LikeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.SenderId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_Likes_Accounts_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_profiles_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Zipcode", "CityName" },
                values: new object[,]
                {
                    { 2000, "Frederiksberg" },
                    { 2625, "Vallensbæk" },
                    { 2650, "Hvidovre" },
                    { 2700, "Brønshøj" },
                    { 2730, "Herlev" },
                    { 2740, "Skovlunde" },
                    { 2791, "Dragør" },
                    { 2860, "Søborg" },
                    { 2980, "Kokkedal" },
                    { 4293, "Dianalund" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Birthdate", "Email", "Firstname", "IsDeleted", "Lastname", "Password", "Username", "Zipcode" },
                values: new object[,]
                {
                    { 1, new DateOnly(1967, 7, 26), "pwe@tec.dk", "Palle", false, "Westermann", "a2", "a1", 2700 },
                    { 2, new DateOnly(2004, 7, 30), "Nikam@Outlook.com", "Nie", false, "Finkam", "ni", "panini", 4293 },
                    { 3, new DateOnly(2000, 1, 1), "Wizmaster@gmail.com", "Albus", true, "Dumbledore", "Wizard", "Al", 2791 },
                    { 4, new DateOnly(1932, 10, 18), "VicTec@hotmail.dk", "Victor", true, "Stone", "Titan", "Cyborg", 2000 }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "ProfileId", "Birthdate", "Gender", "Height", "IsDeleted", "Nickname", "Picture", "Weight" },
                values: new object[,]
                {
                    { 1, new DateOnly(1967, 7, 26), 0, 162, false, "Android 13", null, 0 },
                    { 2, new DateOnly(2004, 7, 30), 1, 80, false, "Nicki", null, 20 },
                    { 3, new DateOnly(2000, 1, 1), 0, 0, true, "GrandMaster", null, 0 },
                    { 4, new DateOnly(1932, 10, 18), 0, 212, true, "Booyah", null, 194 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Zipcode",
                table: "Accounts",
                column: "Zipcode");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ReceiverId",
                table: "Likes",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
