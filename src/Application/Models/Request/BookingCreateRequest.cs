namespace Application.Models.Request
{
    public class BookingCreateRquest
    {
        public int PropertyId { get; set; }
        public string ClientName{ get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly ChekOutDate { get; set; }

        
    }
}