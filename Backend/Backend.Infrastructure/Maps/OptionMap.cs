using Backend.Domain.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Maps;

public class OptionMap : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("Option");
        builder.HasIndex(x => x.Id); 
        builder.Property(x => x.Id).ValueGeneratedOnAdd(); 
        builder.Property(x => x.Name).IsRequired();

        builder.HasOne(o => o.Poll)
            .WithMany(o => o.Options)
            .HasForeignKey(o => o.PoolId);
    }
}