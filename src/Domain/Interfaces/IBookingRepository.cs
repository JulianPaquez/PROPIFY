using domain.Entities;

namespace domain.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<List<Booking>> GetAllWithClientAsync();
    }
}