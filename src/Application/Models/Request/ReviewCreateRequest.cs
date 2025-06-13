using System.ComponentModel.DataAnnotations;
using domain.Entities;

public class ReviewCreateRequest
{
    [Range(1, 5)]
    public int Clasification { get; set; }

    [Required]
    public int IdProp { get; set; }

    [Required]
    public string Comment { get; set; }
}
