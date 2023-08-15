using DNQT.MigrationDb.Configurations;
using DNQT.MigrationDb.DataSeeding;
using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.EF
{
    public class DNQTDbContext : DbContext
    {
        public DNQTDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tao table blank cho database
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new BangAccountConfiguration());
            modelBuilder.ApplyConfiguration(new BangChiTietDonHangConfiguration());
            modelBuilder.ApplyConfiguration(new BangChiTietTienNoConfiguration());
            modelBuilder.ApplyConfiguration(new BangDanhSachDonHangConfiguration());

            modelBuilder.ApplyConfiguration(new BangGiaHanConfiguration());
            modelBuilder.ApplyConfiguration(new BangGiaViThuocConfiguration());
            modelBuilder.ApplyConfiguration(new BangKhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new BangViThuocConfiguration());

            modelBuilder.ApplyConfiguration(new TblHistoryInDepotConfiguration());
            modelBuilder.ApplyConfiguration(new TblJsonConfiguration());
            modelBuilder.ApplyConfiguration(new TblJsonPrintOrderConfiguration());
            modelBuilder.ApplyConfiguration(new TblListNameCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TblListProductInDepotConfiguration());


            //modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            //modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            //modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            //modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //Data seeding
            //Tao du lieu mau cho database blank
            modelBuilder.SeedTaoDuLieuMau();

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<BangAccount> BangAccounts { get; set; }
        public DbSet<BangChiTietDonHang> BangChiTietDonHangs { get; set; }
        public DbSet<BangChiTietTienNo> BangChiTietTienNos { get; set; }
        public DbSet<BangDanhSachDonHang> BangDanhSachDonHangs { get; set; }

        public DbSet<BangGiaHan> BangGiaHans { get; set; }
        public DbSet<BangGiaViThuoc> BangGiaViThuocs { get; set; }
        public DbSet<BangKhachHang> BangKhachHangs { get; set; }
        public DbSet<BangViThuoc> BangViThuocs { get; set; }

        public DbSet<TblHistoryInDepot> TblHistoryInDepots { get; set; }
        public DbSet<TblJson> TblJsons { get; set; }
        public DbSet<TblJsonPrintOrder> TblJsonPrintOrders { get; set; }
        public DbSet<TblListNameCustomer> TblListNameCustomers { get; set; }
        public DbSet<TblListProductInDepot> TblListProductInDepots { get; set; }

    }
}
