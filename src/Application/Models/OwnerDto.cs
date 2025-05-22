using domain.Entities;

public class OwnerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string NumberPhone { get; set; }
    public DocumentType DocumentType { get; set; }
    public string Dni { get; set; }
    public int Cvu { get; set; }


    public static OwnerDTO Create(Owner owner)
    {
        return new OwnerDTO
        {
            Id = owner.Id,
            Name = owner.Name,
            Surname = owner.Surname,
            Email = owner.Email,
            Password = owner.Password,
            NumberPhone = owner.NumberPhone,
            DocumentType = owner.DocumentType,
            Dni = owner.Dni,
            Cvu = owner.Cvu,
        };

    }


    public static List<OwnerDTO> CreateList(IEnumerable<Owner> owners)
    {
        if (owners == null || !owners.Any())
        {
            return null;
        }

        return owners.Select(o => new OwnerDTO
        {
            Id = o.Id,
            Name = o.Name,
            Surname = o.Surname,
            Email = o.Email,
            Password = o.Password,
            NumberPhone = o.NumberPhone,
            DocumentType = o.DocumentType,
            Dni = o.Dni,
            Cvu = o.Cvu,
        }).ToList();
    }

  
}