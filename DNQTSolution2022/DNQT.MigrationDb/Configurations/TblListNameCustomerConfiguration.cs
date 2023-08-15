using DNQT.MigrationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNQT.MigrationDb.Configurations
{
    public class TblListNameCustomerConfiguration : IEntityTypeConfiguration<TblListNameCustomer>
    {
        public void Configure(EntityTypeBuilder<TblListNameCustomer> builder)
        {
            builder.ToTable(nameof(TblListNameCustomer));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.IdBangKhachHang).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.ModifiedBy).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true).HasDefaultValue(1).ValueGeneratedNever();

        }
    }
}
