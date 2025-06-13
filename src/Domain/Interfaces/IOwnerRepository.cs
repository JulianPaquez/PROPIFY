using domain.Entities;
using domain.Interfaces;

public interface IOwnerRepository : IBaseRepository<Owner>
{
    Task<Owner> GetByEmail(string email);
}