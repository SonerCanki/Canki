using Canki.Model.Context;
using Canki.Service.Repository.Base;
using EF = Canki.Model.Entities;

namespace Canki.Service.Repository.Category
{
    public class CategoryRepository : Repository<EF.Category>, ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
