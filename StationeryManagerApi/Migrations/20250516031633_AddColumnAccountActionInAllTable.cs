using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationeryManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnAccountActionInAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountEmail",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAccountName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountEmail",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByAccountName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountEmail",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByAccountName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "InventoryTransactions");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountEmail",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedByAccountName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountEmail",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedByAccountName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountEmail",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdatedByAccountName",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "InventoryTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByAccountId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
