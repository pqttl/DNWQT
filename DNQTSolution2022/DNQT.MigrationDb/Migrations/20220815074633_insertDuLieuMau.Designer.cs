﻿// <auto-generated />
using DNQT.MigrationDb.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNQT.MigrationDb.Migrations
{
    [DbContext(typeof(DNQTDbContext))]
    [Migration("20220815074633_insertDuLieuMau")]
    partial class insertDuLieuMau
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreateTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IsDeleted")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0L);

                    b.Property<string>("ModifyTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("BangAccount");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangChiTietDonHang", b =>
                {
                    b.Property<long>("MaChiTietDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MaDonHang")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MaGiaThuoc")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SoLuongViThuoc")
                        .HasColumnType("REAL");

                    b.Property<long>("ThanhTienTamThoi")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaChiTietDonHang");

                    b.ToTable("BangChiTietDonHang");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangChiTietTienNo", b =>
                {
                    b.Property<long>("IdBangChiTietTienNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdBangKhachHang")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LyDoSuaTienNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("SoTienSuaCuThe")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThoiGianThayDoiTienNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TienNoSauKhiSua")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TienNoTruocKhiSua")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdBangChiTietTienNo");

                    b.ToTable("BangChiTietTienNo");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangDanhSachDonHang", b =>
                {
                    b.Property<long>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CapNhatTienNoChua")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdBangKhachHang")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SdtkhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThoiGianVietDonHangNay")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TienNoCu")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TongGiaTriDonHang")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TongKhoiLuong")
                        .HasColumnType("REAL");

                    b.Property<long>("TongViThuoc")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaDonHang");

                    b.ToTable("BangDanhSachDonHang");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangGiaHan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreateTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EndTimeUse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdAccount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JsonKeyGiaHanGiaiMa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KeyGiaHanMaHoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StartTimeUse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BangGiaHan");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangGiaViThuoc", b =>
                {
                    b.Property<long>("MaGiaThuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DonViGiaThuoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GhiChuGiaThuoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("GiaViThuoc")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MaViThuoc")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThoiGianBatDauCoGiaNay")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThoiGianKetThucGiaNay")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaGiaThuoc");

                    b.ToTable("BangGiaViThuoc");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangKhachHang", b =>
                {
                    b.Property<long>("IdBangKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TienNoHienTai")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdBangKhachHang");

                    b.ToTable("BangKhachHang");

                    b.HasData(
                        new
                        {
                            IdBangKhachHang = 1L,
                            TenKhachHang = "--Không ghi vào--",
                            TienNoHienTai = 0L
                        });
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.BangViThuoc", b =>
                {
                    b.Property<long>("MaViThuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GhiChuViThuoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IsDeleted")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0L);

                    b.Property<string>("TenViThuoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaViThuoc");

                    b.ToTable("BangViThuoc");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.TblHistoryInDepot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdTblListProductInDepot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JsonDonHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LyDoSuaSoLuong")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SoLuongSauKhiSua")
                        .HasColumnType("REAL");

                    b.Property<double>("SoLuongSuaCuThe")
                        .HasColumnType("REAL");

                    b.Property<double>("SoLuongTruocKhiSua")
                        .HasColumnType("REAL");

                    b.Property<long>("Status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1L);

                    b.HasKey("Id");

                    b.ToTable("TblHistoryInDepot");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.TblJson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1L);

                    b.HasKey("Id");

                    b.ToTable("TblJson");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "Do not set",
                            CreatedDate = "2022-08-10 10:16:01",
                            Description = @"{
  ""double.sliderPercentSdt"": 30.0,
  ""List<double>"": [
    6.0,
    29.0,
    10.0,
    12.0,
    19.0,
    24.0
  ],
  ""double.sliderPercentThoiGian"": 48.0
}",
                            Json = @"{
  ""double.sliderPercentSdt"": 30.0,
  ""List<double>"": [
    6.0,
    29.0,
    10.0,
    12.0,
    19.0,
    24.0
  ],
  ""double.sliderPercentThoiGian"": 48.0
}",
                            Keyword = "Json_SizeA5",
                            ModifiedBy = "Do not set",
                            ModifiedDate = "2022-08-10 10:16:01",
                            Status = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = "Do not set",
                            CreatedDate = "2022-08-10 10:16:01",
                            Description = @"{
  ""double.sliderPercentSdt"": 25.0,
  ""List<double>"": [
    6.0,
    43.0,
    11.0,
    9.0,
    14.0,
    17.0
  ],
  ""double.sliderPercentThoiGian"": 40.0
}",
                            Json = @"{
  ""double.sliderPercentSdt"": 25.0,
  ""List<double>"": [
    6.0,
    43.0,
    11.0,
    9.0,
    14.0,
    17.0
  ],
  ""double.sliderPercentThoiGian"": 40.0
}",
                            Keyword = "Json_SizeA4",
                            ModifiedBy = "Do not set",
                            ModifiedDate = "2022-08-10 10:16:01",
                            Status = 1L
                        });
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.TblJsonPrintOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("MaDonHang")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1L);

                    b.HasKey("Id");

                    b.ToTable("TblJsonPrintOrder");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.TblListNameCustomer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdBangKhachHang")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1L);

                    b.HasKey("Id");

                    b.ToTable("TblListNameCustomer");
                });

            modelBuilder.Entity("DNQT.MigrationDb.Entities.TblListProductInDepot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DonVi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("MaViThuoc")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MinQuantity")
                        .HasColumnType("REAL");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("QuantityCurrent")
                        .HasColumnType("REAL");

                    b.Property<long>("Status")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1L);

                    b.HasKey("Id");

                    b.ToTable("TblListProductInDepot");
                });
#pragma warning restore 612, 618
        }
    }
}
