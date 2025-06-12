public class PaymentUpdateRequest
{
    public float Amount { get; set; }
    public float Taxes { get; set; }
    public string State { get; set; }
    public string PaymentMethod { get; set; }
}