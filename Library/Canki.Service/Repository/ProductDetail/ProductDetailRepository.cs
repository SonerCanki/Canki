using Canki.Model.Context;
using Canki.Service.Repository.Base;
using EF = Canki.Model.Entities;
namespace Canki.Service.Repository.ProductDetail
{
    public class ProductDetailRepository : Repository<EF.ProductDetail>, IProductDetailRepository
    {
        private readonly DataContext _dataContext;
        public ProductDetailRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
