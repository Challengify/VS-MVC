using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challengify.Data.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    FullDescription = table.Column<string>(type: "TEXT", nullable: true),
                    MaxParticipants = table.Column<int>(type: "INTEGER", nullable: false),
                    SumOfXP = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IsSubcriber = table.Column<bool>(type: "INTEGER", nullable: false),
                    XP = table.Column<int>(type: "INTEGER", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Challenge",
                columns: new[] { "Id", "FullDescription", "Image", "MaxParticipants", "Name", "ShortDescription", "SumOfXP" },
                values: new object[] { new Guid("16ed300e-fa8a-4d12-a401-52841850f85d"), "full desc", "c:/asdmks/", 3, "challenge name", "short description", 10 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ChallengeId", "Email", "IsSubcriber", "Username", "XP" },
                values: new object[] { new Guid("ba412e49-1aff-4db0-9164-fb9f72c5405b"), null, "mail@mail.com", false, "nickname", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_User_ChallengeId",
                table: "User",
                column: "ChallengeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Challenge");
        }
    }
}
