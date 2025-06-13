using Application.Models;
using Application.Models.Request;
using domain.Entities;

public interface IBookingService
{
    Task<IEnumerable<BookingDTO>> GetAllBookings();
    Task<BookingDTO?> GetBookingById(int id);
    Task<Booking?> AddBooking(BookingCreateRquest dto);
    Task<Booking> UpdateBooking(int id, BookingUpdateRequest request);
    Task DeleteBooking(int id);
}