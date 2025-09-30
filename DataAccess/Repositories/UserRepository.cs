using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CraftToysContext repositoryContext) 
            : base(repositoryContext) 
        {
        }
    }
}
