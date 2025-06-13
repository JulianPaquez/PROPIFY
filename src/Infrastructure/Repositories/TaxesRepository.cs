using infrastructure.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class TaxesRepository : BaseRepository<Taxes>, ITaxesRepository
{
    public TaxesRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Taxes> GetByIdWithUsersAsync(int id)
    {
        return await _context.Taxes
            .Include(t => t.PaidByUser)
            .Include(t => t.ReceivedByUser)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

public async Task<List<Taxes>> GetAllWithUsersAsync()
{
    return await _context.Taxes
        .Include(t => t.PaidByUser)
        .Include(t => t.ReceivedByUser)
        .ToListAsync();
}
}