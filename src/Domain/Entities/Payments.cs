using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payments
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public int ReservaId { get; set; }
    public float Amount { get; set; }
    public float Taxes { get; set; }
    public string State { get; set; }

    public string PaymentMethod { get; set; }

    public Payments() { }

    public Payments(int reservaId, float amoun, float taxes, string state)
    {
        ReservaId = reservaId;
        Amount = amoun;
        Taxes = taxes;
        State = state;

    }
    
}