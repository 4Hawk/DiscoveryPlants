using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoveryPlants.Migrations
{
    public partial class CuentaB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuentaB",
                table: "OngsTab",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuentaB",
                table: "OngsTab");
        }
    }
}
