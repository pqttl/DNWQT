using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class BangAccountConfiguration : IEntityTypeConfiguration<BangAccount>
    {
        public void Configure(EntityTypeBuilder<BangAccount> builder)
        {
            builder.ToTable(nameof(BangAccount));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(0).ValueGeneratedNever();
            builder.Property(x => x.CreateTime).IsRequired(true);
            builder.Property(x => x.ModifyTime).IsRequired(true);

        }
    }
}
