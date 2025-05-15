using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationeryManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldProductSkuInInventoryItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductSku",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSku",
                table: "InventoryItems");
        }
    }
}
