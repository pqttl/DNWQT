using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class TblHistoryInDepotConfiguration : IEntityTypeConfiguration<TblHistoryInDepot>
    {
        public void Configure(EntityTypeBuilder<TblHistoryInDepot> builder)
        {
            builder.ToTable(nameof(TblHistoryInDepot));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdTblListProductInDepot).IsRequired(true);
            builder.Property(x => x.Json).IsRequired(true);
            builder.Property(x => x.JsonDonHang).IsRequired(true);
            builder.Property(x => x.SoLuongTruocKhiSua).IsRequired(true);
            builder.Property(x => x.LyDoSuaSoLuong).IsRequired(true);
            builder.Property(x => x.SoLuongSuaCuThe).IsRequired(true);
            builder.Property(x => x.SoLuongSauKhiSua).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.ModifiedBy).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true).HasDefaultValue(1).ValueGeneratedNever();

        }
    }
}
