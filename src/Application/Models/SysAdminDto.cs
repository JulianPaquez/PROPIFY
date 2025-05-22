using domain.Entities;

public class SysAdminDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string NumberPhone { get; set; }
    public DocumentType DocumentType { get; set; }
    public string Dni { get; set; }


    public static SysAdminDto Create(SysAdmin sysAdmin)
    {
        return new SysAdminDto
        {
            Id = sysAdmin.Id,
            Name = sysAdmin.Name,
            Surname = sysAdmin.Surname,
            Email = sysAdmin.Email,
            Password = sysAdmin.Password,
            NumberPhone = sysAdmin.NumberPhone,
            DocumentType = sysAdmin.DocumentType,
            Dni = sysAdmin.Dni,
        };
    }

    public static List<SysAdminDto> CreateList(IEnumerable<SysAdmin> sysAdmin)
    {
        return sysAdmin.Select(s => Create(s)).ToList();
    }
}