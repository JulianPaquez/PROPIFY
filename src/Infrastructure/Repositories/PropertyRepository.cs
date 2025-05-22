using domain.Entities;
using infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationContext context) : base(context)
    {
    }

    public List<Property> GetAll()
    {
        return _context.Properties.Include(p => p.Owner).ToList();
    }

    public Property GetById(int id)
    {
         return _context.Properties.Include(p => p.Owner).FirstOrDefault(p => p.Id == id);
    }
    
}