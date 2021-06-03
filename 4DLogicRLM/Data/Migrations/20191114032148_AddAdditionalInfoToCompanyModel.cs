using Microsoft.EntityFrameworkCore.Migrations;

namespace _4DLogicRLM.Data.Migrations
{
    public partial class AddAdditionalInfoToCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyCode",
                table: "Companies",
                newName: "ContactPhone");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "BillingInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "BillingInfo");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "Companies",
                newName: "CompanyCode");
        }
    }
}
