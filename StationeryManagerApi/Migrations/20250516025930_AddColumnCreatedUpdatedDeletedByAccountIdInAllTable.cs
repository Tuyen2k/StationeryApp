using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationeryManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnCreatedUpdatedDeletedByAccountIdInAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountId",
                table: "Accounts");
        }
    }
}
