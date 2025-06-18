using domain.Entities;

public class ImageCreateRequest

{

    public int UuidProperty { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public DateTime CreatedDate { get; set; }

}
