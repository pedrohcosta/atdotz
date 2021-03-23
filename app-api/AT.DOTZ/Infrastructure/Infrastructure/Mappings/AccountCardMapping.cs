using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class AccountCardMapping : IEntityTypeConfiguration<AccountCard>
    {
        public void Configure(EntityTypeBuilder<AccountCard> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.ToTable("AccountCard");
        }
    }
}
