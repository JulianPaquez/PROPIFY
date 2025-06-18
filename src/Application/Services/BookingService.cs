using application.Interfaces;
using Application.Models.Request;
using domain.Entities;
using domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<List<Booking>> GetAll()
        {
            return _bookingRepository.GetAll();
        }
        public async Task<Booking?> GetById(int id)
        {
            return _bookingRepository.GetById(id);
        }
        public async Task<Booking?> Create(AddBookingRequest dto)
        {
            var existingClient = /*await*/ _bookingRepository.GetAll();
            if (existingClient.Any(c => c.Id == dto.Id))
            {
                return null;
            }

            var booking = new Booking
            {
                PropertyId = dto.PropertyId,
                UserId = dto.UserId,
                CheckInDate = dto.CheckInDate,
                ChekOutDate = dto.ChekOutDate
            };

            return /*await*/ _bookingRepository.Create(booking);
        }
        public async Task Update(int id, AddBookingRequest request)
        {
            var booking = await GetById(id);
            booking.PropertyId = request.PropertyId;
            booking.UserId = request.UserId;
            booking.CheckInDate = request.CheckInDate;
            booking.ChekOutDate = request.ChekOutDate;

            /*await*/ _bookingRepository.Update(booking);

            return /*booking cuando se haga asincronica*/;
        }
        public async Task Delete(Booking booking)
        {
            /*await*/ _bookingRepository.Delete(booking);
        }
    }
}
