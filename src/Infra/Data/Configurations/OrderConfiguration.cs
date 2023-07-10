using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(p => p.CreatedAt);

        builder.Property(o => o.OrderDate)
            .IsRequired();

        builder.HasOne(o => o.Client)
            .WithMany()
            .HasForeignKey(o => o.ClientId)
            .IsRequired(false);

        builder.Property(o => o.Status)
            .IsRequired()
            .HasConversion<string>();
    }
}