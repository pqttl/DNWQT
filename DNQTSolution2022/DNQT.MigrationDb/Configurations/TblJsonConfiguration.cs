using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class TblJsonConfiguration : IEntityTypeConfiguration<TblJson>
    {
        public void Configure(EntityTypeBuilder<TblJson> builder)
        {
            builder.ToTable(nameof(TblJson));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Keyword).IsRequired(true);
            builder.Property(x => x.Json).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.ModifiedBy).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true).HasDefaultValue(1).ValueGeneratedNever();

        }
    }
}
