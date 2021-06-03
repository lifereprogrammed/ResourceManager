using Microsoft.EntityFrameworkCore.Migrations;

namespace _4DLogicRLM.Data.Migrations
{
    public partial class ALittleMoreInfoOnLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceTypeShortName",
                table: "ResourceTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceTypeShortName",
                table: "ResourceTypes");
        }
    }
}
