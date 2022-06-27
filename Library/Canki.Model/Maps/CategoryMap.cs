using Canki.Core.Map;
using Canki.Model.Entities;
using Canki.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace Canki.Model.Maps
{
    public class CategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Description).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ImageFile).HasMaxLength(50).IsRequired(true);
            });
        }
    }
}
