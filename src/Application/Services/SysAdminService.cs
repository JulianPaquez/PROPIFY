using domain.Entities;

public class SysAdminService : ISysAdminService
{
    private readonly ISysAdminRepository _sysAdminRepository;
    public SysAdminService(ISysAdminRepository sysAdminRepository)
    {
        _sysAdminRepository = sysAdminRepository;
    }

    public List<SysAdminDto> GetAll()
    {
        var list = _sysAdminRepository.GetAll();
        return SysAdminDto.CreateList(list);
    }

    public SysAdminDto GetById(int id)
    {
        var sysAdmin = _sysAdminRepository.GetById(id);
        if (sysAdmin == null)
        {
            throw new Exception("SysAdmin no encontrado");
        }
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

    public SysAdmin Create(SysAdminCreateRequest request)
    {
        var newSysAdmin = new SysAdmin(request.Name, request.Surname, request.Email, request.Password, request.NumberPhone, request.DocumentType, request.Dni);
        _sysAdminRepository.Create(newSysAdmin);
        return newSysAdmin;
    }

    public void Update(int id, SysAdminUpdateRequest request)
    {
        var sysAdmin = _sysAdminRepository.GetById(id);
        if (sysAdmin == null)
        {
            throw new Exception("SysAdmin no encontrado");
        }

        sysAdmin.Name = request.Name;
        sysAdmin.Surname = request.Surname;
        sysAdmin.Email = request.Email;
        sysAdmin.Password = request.Password;
        sysAdmin.NumberPhone = request.NumberPhone;
        sysAdmin.DocumentType = request.DocumentType;
        sysAdmin.Dni = request.Dni;
        _sysAdminRepository.Update(sysAdmin);
    }
    
    public void Delete(int id)
    {
      var sysAdmin = _sysAdminRepository.GetById(id);
        if (sysAdmin == null)
        {

            throw new Exception("Admin no encontrado");
        }
        _sysAdminRepository.Delete(sysAdmin);
    }
}