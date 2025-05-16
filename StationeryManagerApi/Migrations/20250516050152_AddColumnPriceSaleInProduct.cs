using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationeryManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPriceSaleInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceSale",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceSale",
                table: "Products");
        }
    }
}
