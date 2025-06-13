using domain.Entities;
using domain.Interfaces;
using infrastructure.Repositories;
using Infrastructure.Repositories;

public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Owner> GetByEmail(string email)
{
    return _context.Owners.FirstOrDefault(o => o.Email == email);
}
}