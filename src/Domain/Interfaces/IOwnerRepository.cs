using domain.Entities;
using domain.Interfaces;

public interface IOwnerRepository : IBaseRepository<Owner>
{
    Owner GetByEmail(string email);
}