using domain.Entities;

namespace Application.Models
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ClientName { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly ChekOutDate { get; set; }

        public ApprovalState State { get; set; } = ApprovalState.pending;

        public static BookingDTO Create(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                PropertyId = booking.PropertyId,
                ClientName = booking.ClientName?.Name + " " + booking.ClientName?.Surname,
                CheckInDate = booking.CheckInDate,
                ChekOutDate = booking.ChekOutDate,
                State = booking.State
            };
        }

        public static List<BookingDTO> CreateList(IEnumerable<Booking> bookings)
        {
            if (bookings == null || !bookings.Any())
            {
                return null;
            }

            return bookings.Select(Create).ToList();
        }
    }
}