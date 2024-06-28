using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.AddDate);

        Inicialize(builder);
    }

    public abstract void Inicialize(EntityTypeBuilder<T> builder);
}
