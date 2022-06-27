using Canki.Core.Map;
using Canki.Model.Entities;
using Canki.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace Canki.Model.Maps
{
    public class ProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Product>(entity=> 
            {
                entity.ToTable("Products");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Barcode).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Tax).IsRequired(false);
                entity.Property(x => x.StockAmount).IsRequired(false);
                entity.Property(x => x.Discount).IsRequired(false);
                entity.Property(x => x.DiscountType).IsRequired(false);
            
            });
        }
    }
}
