using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations
{
    public partial class RidesOptimisticLocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                "Version",
                "Rides",
                rowVersion: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Version",
                "Rides");
        }
    }
}