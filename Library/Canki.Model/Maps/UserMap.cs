using Canki.Core.Map;
using Canki.Model.Entities;
using Canki.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace Canki.Model.Maps
{
    public class UserMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<User>(entity=> 
            {
                entity.ToTable("Users");

                entity.HasExtended();

                entity.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Email).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.UserName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ImageUrl).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.PhoneNumber).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Password).HasMaxLength(255).IsRequired(true);
                
            });
        }
    }
}
