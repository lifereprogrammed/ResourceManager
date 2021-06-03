using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4DLogicRLM.Data.Migrations
{
    public partial class Jan92020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MakePublic",
                table: "Resources",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrialExpiration",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TrialPeriod",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MakePublic",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "TrialExpiration",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TrialPeriod",
                table: "Accounts");
        }
    }
}
