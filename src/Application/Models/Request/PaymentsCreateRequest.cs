public class PaymentCreateRequest
{
    public int ReservaId { get; set; }
    public float Amount { get; set; }
    public float Taxes { get; set; }
    public string PaymentMethod { get; set; }
}