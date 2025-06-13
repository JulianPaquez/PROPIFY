using domain.Entities;
using domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}