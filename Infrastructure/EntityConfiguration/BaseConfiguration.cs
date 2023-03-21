using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetDevPack.Domain;

namespace Infrastructure.Data.EntityConfiguration;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(c => c.Id);
        Inicialize(builder);
    }

    public abstract void Inicialize(EntityTypeBuilder<T> builder);
}
