using domain.Entities;
using domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context)
        {


        }
        
       public async Task<List<Booking>> GetAllWithClientAsync()
    {
        return await _context.Bookings
            .Include(b => b.ClientName)
            .ToListAsync();
    }
    }
}