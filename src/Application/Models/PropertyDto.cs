using domain.Entities;
using System.ComponentModel.DataAnnotations;

public class PropertyDto
{
    public int Id { get; set; }

    public string Type { get; set; }

    public float SquareMeters { get; set; }

    
    public int PricePerNight { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Street { get; set; }

    
    public int OwnerId { get; set; }
    
    public OwnerPublicDto Owner { get; set; }
    
    public int MaxTenants { get; set; } 

    public string Description { get; set; }
    public PropertyState StateProperty { get; set; }

    public string Bathroom { get; set; }
    public string Room { get; set; }
    public string StreammingPlatform { get; set; }
    public string Pool { get; set; }

    public static PropertyDto Create(Property property)
    {
        return new PropertyDto
        {
            Id = property.Id,
            Type = property.Type,
            SquareMeters = property.SquareMeters,
            PricePerNight = property.PricePerNight,
            Country = property.Country,
            Province = property.Province,
            City = property.City,
            Street = property.Street,
            OwnerId = property.OwnerId,
            Owner = OwnerPublicDto.FromEntity(property.Owner),
            MaxTenants = property.MaxTenants,
            Description = property.Description,
            StateProperty = property.StateProperty,
            Bathroom = property.Bathroom,
            Room = property.Room,
            StreammingPlatform = property.StreammingPlatform,
            Pool = property.Pool,

        };
    }

    public static List<PropertyDto> CreateList(IEnumerable<Property> properties)
    {
        if (properties == null || !properties.Any())
        {
            return null;
        }
        
        return properties.Select(Create).ToList(); // reutilizamos el método

        /* return properties.Select(p => new PropertyDto
        {
            Id = p.Id,
            Type = p.Type,
            SquareMeters = p.SquareMeters,
            PricePerNight = p.PricePerNight,
            OwnerId = p.OwnerId,
            Owner = p.Owner,
            MaxTenants = p.MaxTenants,
            Description = p.Description,
            StateProperty = p.StateProperty,
            Bathroom = p.Bathroom,
            Room = p.Room,
            StreammingPlatform = p.StreammingPlatform,
            Pool = p.Pool,
        }).ToList(); */

    }
}