using Microsoft.EntityFrameworkCore.Migrations;

namespace DNQT.MigrationDb.Migrations
{
    public partial class insertDuLieuMau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BangKhachHang",
                columns: new[] { "IdBangKhachHang", "TenKhachHang", "TienNoHienTai" },
                values: new object[] { 1L, "--Không ghi vào--", 0L });

            migrationBuilder.InsertData(
                table: "TblJson",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Json", "Keyword", "ModifiedBy", "ModifiedDate", "Status" },
                values: new object[] { 1L, "Do not set", "2022-08-10 10:16:01", @"{
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
}", @"{
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
}", "Json_SizeA5", "Do not set", "2022-08-10 10:16:01", 1L });

            migrationBuilder.InsertData(
                table: "TblJson",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Json", "Keyword", "ModifiedBy", "ModifiedDate", "Status" },
                values: new object[] { 2L, "Do not set", "2022-08-10 10:16:01", @"{
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
}", @"{
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
}", "Json_SizeA4", "Do not set", "2022-08-10 10:16:01", 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BangKhachHang",
                keyColumn: "IdBangKhachHang",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TblJson",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TblJson",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
