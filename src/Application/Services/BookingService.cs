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
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPaymentsRepository _paymentsRepository;

        public BookingService(IBookingRepository bookingRepository, IUserRepository userRepository, IPropertyRepository propertyRepository, IPaymentsRepository paymentsRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _propertyRepository = propertyRepository;
            _paymentsRepository = paymentsRepository;
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

            var property = await _propertyRepository.GetByIdAsync(request.PropertyId);
            if (property == null) throw new NotFoundException("Propiedad no encontrada");

            var checkInDate = DateOnly.FromDateTime(request.CheckInDate);
            var checkOutDate = DateOnly.FromDateTime(request.CheckOutDate);

            
            var existingBookings = await _bookingRepository.GetAllAsync();
            bool hayConflicto = existingBookings.Any(b =>
                b.PropertyId == request.PropertyId &&
                checkInDate < b.CheckOutDate &&
                checkOutDate > b.CheckInDate
            );

            if (hayConflicto)
            {
                throw new NotAllowedException("La propiedad ya está reservada en las fechas seleccionadas.");
            }

            var booking = new Booking
            {
                PropertyId = request.PropertyId,
                Property = property,
                ClientName = client,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumbersOfTenants = request.NumbersOfTenants,
            };

            booking.Payments = new Payments
            {
                Amount = booking.TotalPrice,
                Taxes = booking.TotalPrice * 0.1f, // ejemplo: 10% de impuestos
                State = "pendiente",
                PaymentMethod = "Transferencia"
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
            booking.CheckOutDate = DateOnly.FromDateTime(request.CheckOutDate);
            booking.NumbersOfTenants = request.NumbersOfTenants;
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