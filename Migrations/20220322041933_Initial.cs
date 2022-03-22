using Microsoft.EntityFrameworkCore.Migrations;

namespace LaytonTemple.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTimes",
                columns: table => new
                {
                    TimeSlot = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTimes", x => x.TimeSlot);
                });

            migrationBuilder.CreateTable(
                name: "GroupInfo",
                columns: table => new
                {
                    groupName = table.Column<string>(nullable: false),
                    groupSize = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    TimeSlot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupInfo", x => x.groupName);
                    table.ForeignKey(
                        name: "FK_GroupInfo_AvailableTimes_TimeSlot",
                        column: x => x.TimeSlot,
                        principalTable: "AvailableTimes",
                        principalColumn: "TimeSlot",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    groupinfogroupName = table.Column<string>(nullable: true),
                    TimeSlot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_Groups_AvailableTimes_TimeSlot",
                        column: x => x.TimeSlot,
                        principalTable: "AvailableTimes",
                        principalColumn: "TimeSlot",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_GroupInfo_groupinfogroupName",
                        column: x => x.groupinfogroupName,
                        principalTable: "GroupInfo",
                        principalColumn: "groupName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupInfo_TimeSlot",
                table: "GroupInfo",
                column: "TimeSlot");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TimeSlot",
                table: "Groups",
                column: "TimeSlot");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_groupinfogroupName",
                table: "Groups",
                column: "groupinfogroupName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "GroupInfo");

            migrationBuilder.DropTable(
                name: "AvailableTimes");
        }
    }
}
