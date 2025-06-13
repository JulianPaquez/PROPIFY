using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.Entities;

public class Taxes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PaymentId { get; set; }
    public Payments Payments { get; set; }
    public int PaidByUserId { get; set; }
    public User PaidByUser { get; set; }
    public int ReceiveByUserId { get; set; }
    public User ReceivedByUser { get; set; }
    public DateTime IssueDate { get; set; }
    public float TotalTaxes { get; set; }
    public string DescriptionTaxes { get; set; }
    public string PathPDF { get; set; }


    
}