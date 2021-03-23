using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class AccountExtractMapping : IEntityTypeConfiguration<AccountExtract>
    {
        public void Configure(EntityTypeBuilder<AccountExtract> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DocumentCode)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("AccountExtract");
        }

    }
}
