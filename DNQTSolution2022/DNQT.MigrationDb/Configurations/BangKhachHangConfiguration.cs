using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangKhachHangConfiguration : IEntityTypeConfiguration<BangKhachHang>
    {
        public void Configure(EntityTypeBuilder<BangKhachHang> builder)
        {
            builder.ToTable(nameof(BangKhachHang));

            builder.HasKey(x => x.IdBangKhachHang);

            builder.Property(x => x.TenKhachHang).IsRequired(true);
            builder.Property(x => x.TienNoHienTai).IsRequired(true);

        }
    }
}
