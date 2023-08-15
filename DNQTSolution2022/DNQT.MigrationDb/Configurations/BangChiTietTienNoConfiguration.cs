using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangChiTietTienNoConfiguration : IEntityTypeConfiguration<BangChiTietTienNo>
    {
        public void Configure(EntityTypeBuilder<BangChiTietTienNo> builder)
        {
            builder.ToTable(nameof(BangChiTietTienNo));

            builder.HasKey(x => x.IdBangChiTietTienNo);

            builder.Property(x => x.IdBangKhachHang).IsRequired(true);
            builder.Property(x => x.ThoiGianThayDoiTienNo).IsRequired(true);
            builder.Property(x => x.TienNoTruocKhiSua).IsRequired(true);
            builder.Property(x => x.LyDoSuaTienNo).IsRequired(true);
            builder.Property(x => x.SoTienSuaCuThe).IsRequired(true);
            builder.Property(x => x.TienNoSauKhiSua).IsRequired(true);

        }
    }
}
