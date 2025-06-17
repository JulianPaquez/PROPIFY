using domain.Entities;

namespace Application.Models
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ClientName { get; set; } = null!;
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int NumbersOfTenants { get; set; }


        public ApprovalState State { get; set; } = ApprovalState.pending;

        public static BookingDTO Create(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                PropertyId = booking.PropertyId,
                ClientName = booking.ClientName?.Email ?? "Sin Email asignado",
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                NumbersOfTenants = booking.NumbersOfTenants,
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