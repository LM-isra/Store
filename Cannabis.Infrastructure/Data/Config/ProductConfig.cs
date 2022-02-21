using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cannabis.Core.Entities;

namespace Cannabis.Infrastructure.Data.Context.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(180);
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PictureUrl).IsRequired();
        builder.HasOne(y => y.ProductBrand).WithMany()
            .HasForeignKey(x => x.IdProductBrand);
        builder.HasOne(y => y.ProductType).WithMany()
            .HasForeignKey(x => x.IdProductType);

    }
}