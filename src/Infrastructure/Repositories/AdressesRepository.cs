using domain.Entities;
using infrastructure.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class AddressesRepository : BaseRepository<Addresses>, IAdressesRepository
{
    public AddressesRepository(ApplicationContext context) : base(context)
    {
    }

    public List<Addresses> GetAll()
    {
        return _context.Addresses.Include(a => a.IdProperty).ToList();
    }

    public Addresses GetById(int id)
    {
         return _context.Addresses.Include(a => a.IdProperty).FirstOrDefault(a => a.Id == id);
    }
}