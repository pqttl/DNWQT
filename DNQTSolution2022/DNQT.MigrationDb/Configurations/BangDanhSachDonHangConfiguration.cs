using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangDanhSachDonHangConfiguration : IEntityTypeConfiguration<BangDanhSachDonHang>
    {
        public void Configure(EntityTypeBuilder<BangDanhSachDonHang> builder)
        {
            builder.ToTable(nameof(BangDanhSachDonHang));

            builder.HasKey(x => x.MaDonHang);

            builder.Property(x => x.ThoiGianVietDonHangNay).IsRequired(true);
            builder.Property(x => x.TongViThuoc).IsRequired(true);
            builder.Property(x => x.TongKhoiLuong).IsRequired(true);
            builder.Property(x => x.TongGiaTriDonHang).IsRequired(true);
            builder.Property(x => x.IdBangKhachHang).IsRequired(true);
            builder.Property(x => x.SdtkhachHang).IsRequired(true);
            builder.Property(x => x.TienNoCu).IsRequired(true);
            builder.Property(x => x.CapNhatTienNoChua).IsRequired(true);

        }
    }
}
