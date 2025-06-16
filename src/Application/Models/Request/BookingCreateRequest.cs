namespace Application.Models.Request
{
    public class BookingCreateRquest
    {
        public int PropertyId { get; set; }
        public string ClientName{ get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime ChekOutDate { get; set; }

        
    }
}