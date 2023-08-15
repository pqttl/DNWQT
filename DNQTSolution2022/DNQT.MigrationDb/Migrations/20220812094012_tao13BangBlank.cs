using Microsoft.EntityFrameworkCore.Migrations;

namespace DNQT.MigrationDb.Migrations
{
    public partial class tao13BangBlank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<long>(nullable: false, defaultValue: 0L),
                    CreateTime = table.Column<string>(nullable: false),
                    ModifyTime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BangChiTietDonHang",
                columns: table => new
                {
                    MaChiTietDonHang = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaDonHang = table.Column<long>(nullable: false),
                    MaGiaThuoc = table.Column<long>(nullable: false),
                    SoLuongViThuoc = table.Column<double>(nullable: false),
                    ThanhTienTamThoi = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangChiTietDonHang", x => x.MaChiTietDonHang);
                });

            migrationBuilder.CreateTable(
                name: "BangChiTietTienNo",
                columns: table => new
                {
                    IdBangChiTietTienNo = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBangKhachHang = table.Column<long>(nullable: false),
                    ThoiGianThayDoiTienNo = table.Column<string>(nullable: false),
                    TienNoTruocKhiSua = table.Column<long>(nullable: false),
                    LyDoSuaTienNo = table.Column<string>(nullable: false),
                    SoTienSuaCuThe = table.Column<long>(nullable: false),
                    TienNoSauKhiSua = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangChiTietTienNo", x => x.IdBangChiTietTienNo);
                });

            migrationBuilder.CreateTable(
                name: "BangDanhSachDonHang",
                columns: table => new
                {
                    MaDonHang = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ThoiGianVietDonHangNay = table.Column<string>(nullable: false),
                    TongViThuoc = table.Column<long>(nullable: false),
                    TongKhoiLuong = table.Column<double>(nullable: false),
                    TongGiaTriDonHang = table.Column<long>(nullable: false),
                    IdBangKhachHang = table.Column<long>(nullable: false),
                    SdtkhachHang = table.Column<string>(nullable: false),
                    TienNoCu = table.Column<long>(nullable: false),
                    CapNhatTienNoChua = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangDanhSachDonHang", x => x.MaDonHang);
                });

            migrationBuilder.CreateTable(
                name: "BangGiaHan",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAccount = table.Column<long>(nullable: false),
                    StartTimeUse = table.Column<string>(nullable: false),
                    EndTimeUse = table.Column<string>(nullable: false),
                    CreateTime = table.Column<string>(nullable: false),
                    JsonKeyGiaHanGiaiMa = table.Column<string>(nullable: false),
                    KeyGiaHanMaHoa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGiaHan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BangGiaViThuoc",
                columns: table => new
                {
                    MaGiaThuoc = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaViThuoc = table.Column<long>(nullable: false),
                    GiaViThuoc = table.Column<long>(nullable: false),
                    DonViGiaThuoc = table.Column<string>(nullable: false),
                    ThoiGianBatDauCoGiaNay = table.Column<string>(nullable: false),
                    ThoiGianKetThucGiaNay = table.Column<string>(nullable: false),
                    GhiChuGiaThuoc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGiaViThuoc", x => x.MaGiaThuoc);
                });

            migrationBuilder.CreateTable(
                name: "BangKhachHang",
                columns: table => new
                {
                    IdBangKhachHang = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenKhachHang = table.Column<string>(nullable: false),
                    TienNoHienTai = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangKhachHang", x => x.IdBangKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "BangViThuoc",
                columns: table => new
                {
                    MaViThuoc = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenViThuoc = table.Column<string>(nullable: false),
                    GhiChuViThuoc = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<long>(nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangViThuoc", x => x.MaViThuoc);
                });

            migrationBuilder.CreateTable(
                name: "TblHistoryInDepot",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdTblListProductInDepot = table.Column<long>(nullable: false),
                    Json = table.Column<string>(nullable: false),
                    JsonDonHang = table.Column<string>(nullable: false),
                    SoLuongTruocKhiSua = table.Column<double>(nullable: false),
                    LyDoSuaSoLuong = table.Column<string>(nullable: false),
                    SoLuongSuaCuThe = table.Column<double>(nullable: false),
                    SoLuongSauKhiSua = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedDate = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    Status = table.Column<long>(nullable: false, defaultValue: 1L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHistoryInDepot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblJson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(nullable: false),
                    Json = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedDate = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    Status = table.Column<long>(nullable: false, defaultValue: 1L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblJsonPrintOrder",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Json = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MaDonHang = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedDate = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    Status = table.Column<long>(nullable: false, defaultValue: 1L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJsonPrintOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblListNameCustomer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IdBangKhachHang = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedDate = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    Status = table.Column<long>(nullable: false, defaultValue: 1L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblListNameCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblListProductInDepot",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Json = table.Column<string>(nullable: false),
                    MaViThuoc = table.Column<long>(nullable: false),
                    QuantityCurrent = table.Column<double>(nullable: false),
                    MinQuantity = table.Column<double>(nullable: false),
                    DonVi = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedDate = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    Status = table.Column<long>(nullable: false, defaultValue: 1L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblListProductInDepot", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangAccount");

            migrationBuilder.DropTable(
                name: "BangChiTietDonHang");

            migrationBuilder.DropTable(
                name: "BangChiTietTienNo");

            migrationBuilder.DropTable(
                name: "BangDanhSachDonHang");

            migrationBuilder.DropTable(
                name: "BangGiaHan");

            migrationBuilder.DropTable(
                name: "BangGiaViThuoc");

            migrationBuilder.DropTable(
                name: "BangKhachHang");

            migrationBuilder.DropTable(
                name: "BangViThuoc");

            migrationBuilder.DropTable(
                name: "TblHistoryInDepot");

            migrationBuilder.DropTable(
                name: "TblJson");

            migrationBuilder.DropTable(
                name: "TblJsonPrintOrder");

            migrationBuilder.DropTable(
                name: "TblListNameCustomer");

            migrationBuilder.DropTable(
                name: "TblListProductInDepot");
        }
    }
}
