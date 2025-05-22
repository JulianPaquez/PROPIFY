using domain.Entities;

public class AddressesDto
{
    public int Id { get; set; }
    public int IdProperty { get; set; }

    public string Street { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int Floor { get; set; }
    public string Decorated { get; set; }
    public string Observations { get; set; }
    public double Latitude { get; set; }
    public double Length { get; set; }

    public static AddressesDto Create(Addresses addresses)
    {
        return new AddressesDto
        {
            Id = addresses.Id,
            IdProperty = addresses.IdProperty,
            Street = addresses.Street,
            Country = addresses.Country,
            City = addresses.City,
            Floor = addresses.Floor,
            Decorated = addresses.Decorated,
            Observations = addresses.Observations,
            Latitude = addresses.Latitude,
            Length = addresses.Length,
        };
    }

    public static List<AddressesDto> CreateList(IEnumerable<Addresses> addresses)
    {
        if (addresses == null || !addresses.Any())
        {
            return null;
        }

        return addresses.Select(Create).ToList();
    }
}