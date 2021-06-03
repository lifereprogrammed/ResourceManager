using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4DLogicRLM.Data.Migrations
{
    public partial class AddedDatesAndDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceDescription",
                table: "Resources",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceDescription",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "AspNetUsers");
        }
    }
}
