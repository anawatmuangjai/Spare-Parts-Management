using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SPM.Core.Models;

namespace SPM.Infrastructure.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBarcode> ProductBarcode { get; set; }
        public virtual DbSet<ProductBusiness> ProductBusiness { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductInventory> ProductInventory { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductShelf> ProductShelf { get; set; }
        public virtual DbSet<ProductThumbnail> ProductThumbnail { get; set; }
        public virtual DbSet<ProductTransaction> ProductTransaction { get; set; }
        public virtual DbSet<ProductVendor> ProductVendor { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<SalesReason> SalesReason { get; set; }
        public virtual DbSet<ShipLocation> ShipLocation { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MMS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IsAdmin)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(30);

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Photo).HasColumnType("image");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductNumber)
                    .HasName("UQ__Product__49A3C839CB4781DB")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ShelfId).HasColumnName("ShelfID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ShelfId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductBarcode>(entity =>
            {
                entity.HasKey(e => e.BarcodeId);

                entity.Property(e => e.BarcodeId).HasColumnName("BarcodeID");

                entity.Property(e => e.BarcodeText)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BarcodeType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.BarcodeVendor)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProductVendorId).HasColumnName("ProductVendorID");

                entity.HasOne(d => d.ProductVendor)
                    .WithMany(p => p.ProductBarcode)
                    .HasForeignKey(d => d.ProductVendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductBusiness>(entity =>
            {
                entity.HasKey(e => e.BusinessId);

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__ProductC__8517B2E05A19B16B")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.HasIndex(e => e.GroupName)
                    .HasName("UQ__ProductG__6EFCD4349AB3E95B")
                    .IsUnique();

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductGroup)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductGruop_ProductCategory_CategoryID");
            });

            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId);

                entity.HasIndex(e => e.ProductSerial)
                    .HasName("UQ__ProductI__CA1677123643741B")
                    .IsUnique();

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductSerial)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.ProductInventory)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProductInventory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ThumbnailId });

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ThumbnailId).HasColumnName("ThumbnailID");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrimaryPhoto)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPhoto)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Thumbnail)
                    .WithMany(p => p.ProductPhoto)
                    .HasForeignKey(d => d.ThumbnailId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductShelf>(entity =>
            {
                entity.HasKey(e => e.ShelfId);

                entity.HasIndex(e => e.ShelfName)
                    .HasName("UQ__ProductS__A338F034107124A5")
                    .IsUnique();

                entity.Property(e => e.ShelfId).HasColumnName("ShelfID");

                entity.Property(e => e.ShelfGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShelfName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductThumbnail>(entity =>
            {
                entity.HasKey(e => e.ThumbnailId);

                entity.Property(e => e.ThumbnailId).HasColumnName("ThumbnailID");

                entity.Property(e => e.ThumbnailFileName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ThumbnailPhoto).IsRequired();
            });

            modelBuilder.Entity<ProductTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransectionType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTransaction)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductVendor>(entity =>
            {
                entity.Property(e => e.ProductVendorId).HasColumnName("ProductVendorID");

                entity.Property(e => e.LastReceiptPrice).HasColumnType("money");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVendor)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.ProductVendor)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.OrderStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId);

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.RequireDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ReasonId).HasColumnName("ReasonID");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Reason)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.ReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesOrder_SaleReason_ReasonID");
            });

            modelBuilder.Entity<SalesReason>(entity =>
            {
                entity.HasKey(e => e.ReasonId);

                entity.Property(e => e.ReasonId).HasColumnName("ReasonID");

                entity.Property(e => e.ReasonCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ReasonName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ShipLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LocationGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasIndex(e => e.VendorName)
                    .HasName("UQ__Vendor__7320A3572B7D39BC")
                    .IsUnique();

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.ActiveStatus)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
