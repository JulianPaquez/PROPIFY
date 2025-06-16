using Application.Models;
using Application.Models.Request;
using domain.Entities;
using domain.Interfaces;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
    //private readonly IPropertyRepository _propertyRepository;

        public BookingService(IBookingRepository bookingRepository, IUserRepository userRepository, IPropertyRepository propertyRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
           // _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookings()
        {
            var booking = await _bookingRepository.GetAllWithClientAsync();
            return BookingDTO.CreateList(booking);
        }
        
        public async Task<BookingDTO?> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                throw new NotFoundException("Reserva no encontrada");
            }

            return BookingDTO.Create(booking);
        }
        public async Task<Booking?> AddBooking(BookingCreateRquest request)
        {
            var client = await _userRepository.GetByEmail(request.ClientName);
            if (client == null) throw new NotFoundException("La reserva no pudo ser creada.");


            var booking = new Booking
            {
                PropertyId = request.PropertyId,
                ClientName = client,
                CheckInDate = DateOnly.FromDateTime(request.CheckInDate),
                ChekOutDate = DateOnly.FromDateTime(request.ChekOutDate)    
            };

             await _bookingRepository.CreateAsync(booking);
            return booking;
        }
        public async Task<Booking> UpdateBooking(int id, BookingUpdateRequest request)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                throw new NotFoundException("No se encontró la reserva a actualizar.");
            }
            booking.CheckInDate = DateOnly.FromDateTime(request.CheckInDate);
            booking.ChekOutDate = DateOnly.FromDateTime(request.ChekOutDate);
            booking.State = request.Statetate;

            await _bookingRepository.UpdateAsync(booking);

            return booking;
        }
        public async Task DeleteBooking(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                throw new NotFoundException("No se encontró la reserva a actualizar.");
            }

            await _bookingRepository.DeleteAsync(booking);
        }
    }
}