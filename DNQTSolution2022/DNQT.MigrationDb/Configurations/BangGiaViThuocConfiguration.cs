using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangGiaViThuocConfiguration : IEntityTypeConfiguration<BangGiaViThuoc>
    {
        public void Configure(EntityTypeBuilder<BangGiaViThuoc> builder)
        {
            builder.ToTable(nameof(BangGiaViThuoc));

            builder.HasKey(x => x.MaGiaThuoc);

            builder.Property(x => x.MaViThuoc).IsRequired(true);
            builder.Property(x => x.GiaViThuoc).IsRequired(true);
            builder.Property(x => x.DonViGiaThuoc).IsRequired(true);
            builder.Property(x => x.ThoiGianBatDauCoGiaNay).IsRequired(true);
            builder.Property(x => x.ThoiGianKetThucGiaNay).IsRequired(true);
            builder.Property(x => x.GhiChuGiaThuoc).IsRequired(true);

        }
    }
}
