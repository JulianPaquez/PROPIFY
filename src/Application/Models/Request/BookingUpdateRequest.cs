public class BookingUpdateRequest
{
    public DateOnly CheckInDate { get; set; }
    public DateOnly ChekOutDate { get; set; }
    public ApprovalState Statetate { get; set; }

        
    }