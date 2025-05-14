using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;

namespace StationeryManagerApi
{
    public class StationeryDBContext : DbContext
    {
        public StationeryDBContext(DbContextOptions<StationeryDBContext> options) : base(options) {}

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<WarehouseModel> Warehouses { get; set; }
        public DbSet<InventoryTransactionModel> InventoryTransactions { get; set; } 
        public DbSet<InventoryItemModel> InventoryItems { get; set; }
        public DbSet<ProductInventoryView> ProductInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().ToTable("Accounts");
            modelBuilder.Entity<CategoryModel>().ToTable("Categories");
            modelBuilder.Entity<SubCategoryModel>().ToTable("SubCategories");
            modelBuilder.Entity<ProductModel>().ToTable("Products");
            modelBuilder.Entity<WarehouseModel>().ToTable("Warehouses");
            modelBuilder.Entity<InventoryTransactionModel>().ToTable("InventoryTransactions");
            modelBuilder.Entity<InventoryItemModel>().ToTable("InventoryItems");

            // configure view
            var productInventoryView = modelBuilder.Entity<ProductInventoryView>();
            productInventoryView.HasKey(p => p.ProductId);         
            productInventoryView.ToView("vw_ProductInventory");    

            base.OnModelCreating(modelBuilder);
        }

    }
}
