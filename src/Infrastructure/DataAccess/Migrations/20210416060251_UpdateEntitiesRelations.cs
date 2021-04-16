using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations
{
    public partial class UpdateEntitiesRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Customers_CustomerId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Drivers_DriverId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Customers_CustomerId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Customers_CustomerId",
                table: "Rides");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                table: "Rides",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Rides",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "PaymentMethods",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Opinions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Opinions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Opinions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Opinions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Coupons",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Customers_CustomerId",
                table: "Opinions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Drivers_DriverId",
                table: "Opinions",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Customers_CustomerId",
                table: "PaymentMethods",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Customers_CustomerId",
                table: "Rides",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Customers_CustomerId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Drivers_DriverId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Customers_CustomerId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Customers_CustomerId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Coupons");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                table: "Rides",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Rides",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "PaymentMethods",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Opinions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Opinions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Customers_CustomerId",
                table: "Opinions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Drivers_DriverId",
                table: "Opinions",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Customers_CustomerId",
                table: "PaymentMethods",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Customers_CustomerId",
                table: "Rides",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
