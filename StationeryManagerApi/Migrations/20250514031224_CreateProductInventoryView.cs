using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationeryManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductInventoryView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.views WHERE name = 'vw_ProductInventory')
                BEGIN
                    EXEC('
                        CREATE VIEW vw_ProductInventory AS
                        SELECT 
                            ProductId,
                            MAX(ProductName) AS ProductName,
                            SUM(Quantity) AS TotalQuantity
                        FROM InventoryItems
                        GROUP BY ProductId;
                    ')
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vw_ProductInventory;");
        }
    }
}
