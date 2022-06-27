using Microsoft.EntityFrameworkCore;

namespace Canki.Core.Map
{
    public interface IEntityBuilder
    {
        void Build(ModelBuilder builder);
    }
}
