public class BookingUpdateRequest
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public ApprovalState Statetate { get; set; }
    public int NumbersOfTenants { get; set; }

        
    }