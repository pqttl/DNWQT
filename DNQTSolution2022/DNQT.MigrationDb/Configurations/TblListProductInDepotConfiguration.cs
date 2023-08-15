using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class TblListProductInDepotConfiguration : IEntityTypeConfiguration<TblListProductInDepot>
    {
        public void Configure(EntityTypeBuilder<TblListProductInDepot> builder)
        {
            builder.ToTable(nameof(TblListProductInDepot));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Json).IsRequired(true);
            builder.Property(x => x.MaViThuoc).IsRequired(true);
            builder.Property(x => x.QuantityCurrent).IsRequired(true);
            builder.Property(x => x.MinQuantity).IsRequired(true);
            builder.Property(x => x.DonVi).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.ModifiedBy).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true).HasDefaultValue(1).ValueGeneratedNever();

        }
    }
}
