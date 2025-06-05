using domain.Entities;
using Domain.Interfaces;
using infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
        public User? GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(p => p.Email == email);
        }
    

    }
}