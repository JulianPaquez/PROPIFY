using domain.Entities;
using domain.Interfaces;
using Infrastructure.Repositories;

namespace infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context)
        {

            
        }
    }
}