using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangGiaHanConfiguration : IEntityTypeConfiguration<BangGiaHan>
    {
        public void Configure(EntityTypeBuilder<BangGiaHan> builder)
        {
            builder.ToTable(nameof(BangGiaHan));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdAccount).IsRequired(true);
            builder.Property(x => x.StartTimeUse).IsRequired(true);
            builder.Property(x => x.EndTimeUse).IsRequired(true);
            builder.Property(x => x.CreateTime).IsRequired(true);
            builder.Property(x => x.JsonKeyGiaHanGiaiMa).IsRequired(true);
            builder.Property(x => x.KeyGiaHanMaHoa).IsRequired(true);

        }
    }
}
