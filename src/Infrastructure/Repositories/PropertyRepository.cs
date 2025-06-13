using domain.Entities;
using infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<List<Property>> GetAllAsync()
{
    return await _context.Properties
        .Include(p => p.Owner)
        .ToListAsync();
}

public async Task<Property> GetByIdAsync(int id)
{
    return await _context.Properties
        .Include(p => p.Owner)
        .FirstOrDefaultAsync(p => p.Id == id);
}
    
}