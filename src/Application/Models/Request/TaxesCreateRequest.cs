public class TaxesCreateRequest
{
    public int PaymentId { get; set; }
    public string PayerEmail { get; set; }
    public string ReceiverEmail { get; set; }
    public DateTime IssueData { get; set; }
    public float TotalTaxes { get; set; }
    public string DescriptionTaxes { get; set; }
    public string PathPDF { get; set; }

}