using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangViThuocConfiguration : IEntityTypeConfiguration<BangViThuoc>
    {
        public void Configure(EntityTypeBuilder<BangViThuoc> builder)
        {
            builder.ToTable(nameof(BangViThuoc));

            builder.HasKey(x => x.MaViThuoc);

            builder.Property(x => x.TenViThuoc).IsRequired(true);
            builder.Property(x => x.GhiChuViThuoc).IsRequired(true);
            builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(0).ValueGeneratedNever();

        }
    }
}
