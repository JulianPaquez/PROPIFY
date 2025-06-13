public class TaxesDto
{
    public int Id { get; set; }

    public int PaymentId { get; set; }

    public string PaidByUserName { get; set; }
    public string ReceivedByUserName { get; set; }

    public DateTime IssueDate { get; set; }

    public float TotalTaxes { get; set; }
    public string DescriptionTaxes { get; set; }
    public string PathPDF { get; set; }

    public static TaxesDto Create(Taxes taxes)
    {
        return new TaxesDto
        {
            Id = taxes.Id,
            PaymentId = taxes.PaymentId,
            PaidByUserName = taxes.PaidByUser?.Name + " " + taxes.PaidByUser?.Surname,
            ReceivedByUserName = taxes.ReceivedByUser?.Name + " " + taxes.ReceivedByUser?.Surname,
            IssueDate = taxes.IssueDate,
            TotalTaxes = taxes.TotalTaxes,
            DescriptionTaxes = taxes.DescriptionTaxes,
            PathPDF = taxes.PathPDF
        };
    }

    public static List<TaxesDto> CreateList(IEnumerable<Taxes> taxes)
    {
        if (taxes == null || !taxes.Any())
        {
            return null;
        }

        return taxes.Select(Create).ToList();
    }
}