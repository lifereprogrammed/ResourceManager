using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4DLogicRLM.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<Guid>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    AccountUserID = table.Column<string>(nullable: true),
                    SubscriptionID = table.Column<int>(nullable: false),
                    SubscriptionPlanFee = table.Column<double>(nullable: false),
                    SubscriptionUserCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "BillingInfo",
                columns: table => new
                {
                    BillingID = table.Column<Guid>(nullable: false),
                    BillingAddress1 = table.Column<string>(nullable: true),
                    BillingAddress2 = table.Column<string>(nullable: true),
                    BillingState = table.Column<string>(nullable: true),
                    BillingCity = table.Column<string>(nullable: true),
                    BillingZip = table.Column<string>(nullable: true),
                    BillingCountry = table.Column<string>(nullable: true),
                    BillingPhone = table.Column<string>(nullable: true),
                    BillingRecentDate = table.Column<DateTime>(nullable: false),
                    BillingExpireDate = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInfo", x => x.BillingID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true),
                    CountryShortName = table.Column<string>(nullable: true),
                    KMLFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(nullable: true),
                    LocationType = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    LatLon = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
                    ConvertedLatLon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    LocationTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationTypeName = table.Column<string>(nullable: true),
                    LocationTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.LocationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProvinceName = table.Column<string>(nullable: true),
                    ProvinceShortName = table.Column<string>(nullable: true),
                    KMLFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceQuantityTypes",
                columns: table => new
                {
                    ResourceQuantityTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResournceQuantityTypeName = table.Column<string>(nullable: true),
                    ResournceQuantityTypeDescription = table.Column<string>(nullable: true),
                    ResourceQuantityTypeShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceQuantityTypes", x => x.ResourceQuantityTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResourceName = table.Column<string>(nullable: true),
                    ResourceTypeID = table.Column<int>(nullable: false),
                    RescourceQty = table.Column<double>(nullable: false),
                    ResourceQtyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    ResourceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResourceTypeName = table.Column<string>(nullable: true),
                    ResourceTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.ResourceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    SubscriptionPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubscriptionPlanName = table.Column<string>(nullable: true),
                    SubscriptionPlanDescription = table.Column<string>(nullable: true),
                    SubscriptionPlanFee = table.Column<double>(nullable: false),
                    SubscriptionUserCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.SubscriptionPlanID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BillingInfo");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "ResourceQuantityTypes");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");
        }
    }
}
