public class PaymentsDto
{
    public int Id { get; set; }

    public int ReservaId { get; set; }
    
    public float Amount { get; set; } //despues el monto ,mediante inyeccion de dependencia se va a juntar con el construcotr de reservas
    
    public float Taxes { get; set; }
    
    public string State { get; set; }

    public string PaymentMethod { get; set; }

    public static PaymentsDto Create(Payments payments)
    {
        return new PaymentsDto
        {
            Id = payments.Id,
            ReservaId = payments.ReservaId,
            Amount = payments.Amount,
            Taxes = payments.Taxes,
            State = payments.State,
            PaymentMethod = payments.PaymentMethod,
        };
    }

    public static List<PaymentsDto> CreateList(IEnumerable<Payments> payments)
    {
        if (payments == null || !payments.Any())
        {
            return null;
        }

        return payments.Select(Create).ToList();

    }
}