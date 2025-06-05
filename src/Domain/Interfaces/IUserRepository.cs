using domain.Entities;
using domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User ? GetByEmail(string email);
    }
}