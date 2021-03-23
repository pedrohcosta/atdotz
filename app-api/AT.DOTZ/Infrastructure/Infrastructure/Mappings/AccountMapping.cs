using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Entities;

namespace Infrastructure.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Mail)
                .IsRequired()
                .HasColumnType("varchar(150)");
            
            builder.Property(p => p.Number)
               .IsRequired()
               .HasColumnType("varchar(20)");

          
            builder.ToTable("Account");
        }
    }
}
