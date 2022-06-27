using Canki.Model.Context;
using Canki.Service.Repository.Base;
using EF = Canki.Model.Entities;

namespace Canki.Service.Repository.User
{
    public class UserRepository : Repository<EF.User>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
