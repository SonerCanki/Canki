using Canki.Core.Map;
using Canki.Model.Entities;
using Canki.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace Canki.Model.Maps
{
    public class ProductDetailMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductDetail>(entity=> 
            {
                entity.ToTable("ProductDetails");

                entity.HasExtended();

                entity.Property(x => x.Detail).HasMaxLength(1024).IsRequired(true);
                entity.Property(x => x.ExtraDetail).HasMaxLength(1024).IsRequired(false);


                entity
                    .HasOne(x => x.Product)
                    .WithMany(x => x.ProductDetails)
                    .HasForeignKey(x => x.ProductId);
            });
        }
    }
}
