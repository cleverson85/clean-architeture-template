using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration;

public class BookConfiguration : BaseConfiguration<Book>
{
    public override void Inicialize(EntityTypeBuilder<Book> builder)
    {
        builder.Property(c => c.Title)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(c => c.Author)
               .HasMaxLength(150)
               .IsRequired();
    }
}
