using domain.Entities;

public class OwnerPublicDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
    public int Cvu { get; set; }

    public static OwnerPublicDto FromEntity(Owner owner)
    {
        return new OwnerPublicDto
        {
            Name = owner.Name,
            Surname = owner.Surname,
            Email = owner.Email,
            NumberPhone = owner.NumberPhone,
            Cvu = owner.Cvu
        };
    }
}