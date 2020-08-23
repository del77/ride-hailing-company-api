using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CurrentUsesCounter = table.Column<int>(nullable: false),
                    AdmissibleUses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponUsers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    CouponId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponUsers", x => new { x.CouponId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CouponUsers_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DriverId = table.Column<string>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinions_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DriverId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: false),
                    Origin_Latitude = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Origin_Longitude = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Destination_Latitude = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Destination_Longitude = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Cost_Value = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    CouponId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rides_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rides_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rides_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsers_CustomerId",
                table: "CouponUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_CustomerId",
                table: "Opinions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_DriverId",
                table: "Opinions",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CustomerId",
                table: "PaymentMethods",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_CouponId",
                table: "Rides",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_CustomerId",
                table: "Rides",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DriverId",
                table: "Rides",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponUsers");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
