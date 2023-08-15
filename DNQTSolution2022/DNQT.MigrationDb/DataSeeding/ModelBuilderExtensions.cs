using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace DNQT.MigrationDb.DataSeeding
{
    public static class ModelBuilderExtensions
    {
        public static void SeedTaoDuLieuMau(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangKhachHang>().HasData(
               new BangKhachHang() { IdBangKhachHang = 1, TenKhachHang = "--Không ghi vào--", TienNoHienTai = 0 }
               );

            string strDateTemp = "2022-08-10 10:16:01";
            string strUserTemp = "Do not set";

            {
                string strJson = @"{
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
}";
                modelBuilder.Entity<TblJson>().HasData(
                   new TblJson()
                   {
                       Id = 1,
                       Keyword = "Json_SizeA5",
                       Json = strJson,Description=strJson,CreatedDate= strDateTemp,CreatedBy=strUserTemp,ModifiedDate=strDateTemp,ModifiedBy=strUserTemp,Status=1
                   }
                   );
            }
            
            {
                string strJson = @"{
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
}";
                modelBuilder.Entity<TblJson>().HasData(
                   new TblJson()
                   {
                       Id = 2,
                       Keyword = "Json_SizeA4",
                       Json = strJson,Description=strJson,CreatedDate= strDateTemp,CreatedBy=strUserTemp,ModifiedDate=strDateTemp,ModifiedBy=strUserTemp,Status=1
                   }
                   );
            }


        }
    }
}
