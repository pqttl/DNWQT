using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangChiTietDonHangConfiguration : IEntityTypeConfiguration<BangChiTietDonHang>
    {
        public void Configure(EntityTypeBuilder<BangChiTietDonHang> builder)
        {
            builder.ToTable(nameof(BangChiTietDonHang));

            builder.HasKey(x => x.MaChiTietDonHang);

            builder.Property(x => x.MaDonHang).IsRequired(true);
            builder.Property(x => x.MaGiaThuoc).IsRequired(true);
            builder.Property(x => x.SoLuongViThuoc).IsRequired(true);
            builder.Property(x => x.ThanhTienTamThoi).IsRequired(true);

        }
    }
}
