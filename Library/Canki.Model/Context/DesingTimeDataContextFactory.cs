using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Canki.Model.Context
{
    public class DesingTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../Canki.Api")
            };
            return resolver.ServiceProvider.GetService(typeof(DataContext)) as DataContext;
        }
    }
}
