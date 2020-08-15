using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Coupons",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Code = table.Column<string>(),
                    DiscountPercent = table.Column<decimal>(),
                    CurrentUsesCounter = table.Column<int>(),
                    AdmissibleUses = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Coupons", x => x.Id); });

            migrationBuilder.CreateTable(
                "Customers",
                table => new
                {
                    Id = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Customers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Drivers",
                table => new
                {
                    Id = table.Column<string>(),
                    Vehicle_Brand = table.Column<string>(nullable: true),
                    Vehicle_Model = table.Column<string>(nullable: true),
                    Vehicle_Seats = table.Column<int>(nullable: true),
                    Vehicle_RegistrationNumber = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Drivers", x => x.Id); });

            migrationBuilder.CreateTable(
                "CouponUsers",
                table => new
                {
                    CustomerId = table.Column<string>(),
                    CouponId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponUsers", x => new {x.CouponId, x.CustomerId});
                    table.ForeignKey(
                        "FK_CouponUsers_Coupons_CouponId",
                        x => x.CouponId,
                        "Coupons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CouponUsers_Customers_CustomerId",
                        x => x.CustomerId,
                        "Customers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PaymentMethods",
                table => new
                {
                    Id = table.Column<Guid>(),
                    CardId = table.Column<string>(),
                    Last4 = table.Column<string>(),
                    CustomerId = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        "FK_PaymentMethods_Customers_CustomerId",
                        x => x.CustomerId,
                        "Customers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Opinions",
                table => new
                {
                    Id = table.Column<Guid>(),
                    DriverId = table.Column<string>(),
                    Value = table.Column<int>(),
                    Description = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        "FK_Opinions_Drivers_DriverId",
                        x => x.DriverId,
                        "Drivers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Rides",
                table => new
                {
                    Id = table.Column<Guid>(),
                    DriverId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(),
                    Origin_Address = table.Column<string>(nullable: true),
                    Origin_Latitude = table.Column<decimal>(nullable: true),
                    Origin_Longitude = table.Column<decimal>(nullable: true),
                    Destination_Address = table.Column<string>(nullable: true),
                    Destination_Latitude = table.Column<decimal>(nullable: true),
                    Destination_Longitude = table.Column<decimal>(nullable: true),
                    Cost_Currency = table.Column<string>(nullable: true),
                    Cost_Value = table.Column<decimal>(nullable: true),
                    CouponId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        "FK_Rides_Coupons_CouponId",
                        x => x.CouponId,
                        "Coupons",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Rides_Customers_CustomerId",
                        x => x.CustomerId,
                        "Customers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Rides_Drivers_DriverId",
                        x => x.DriverId,
                        "Drivers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_CouponUsers_CustomerId",
                "CouponUsers",
                "CustomerId");

            migrationBuilder.CreateIndex(
                "IX_Opinions_DriverId",
                "Opinions",
                "DriverId");

            migrationBuilder.CreateIndex(
                "IX_PaymentMethods_CustomerId",
                "PaymentMethods",
                "CustomerId");

            migrationBuilder.CreateIndex(
                "IX_Rides_CouponId",
                "Rides",
                "CouponId");

            migrationBuilder.CreateIndex(
                "IX_Rides_CustomerId",
                "Rides",
                "CustomerId");

            migrationBuilder.CreateIndex(
                "IX_Rides_DriverId",
                "Rides",
                "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CouponUsers");

            migrationBuilder.DropTable(
                "Opinions");

            migrationBuilder.DropTable(
                "PaymentMethods");

            migrationBuilder.DropTable(
                "Rides");

            migrationBuilder.DropTable(
                "Coupons");

            migrationBuilder.DropTable(
                "Customers");

            migrationBuilder.DropTable(
                "Drivers");
        }
    }
}