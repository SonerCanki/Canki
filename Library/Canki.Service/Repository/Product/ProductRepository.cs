using Canki.Model.Context;
using Canki.Service.Repository.Base;
using EF = Canki.Model.Entities;
namespace Canki.Service.Repository.Product
{
    public class ProductRepository : Repository<EF.Product> , IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
