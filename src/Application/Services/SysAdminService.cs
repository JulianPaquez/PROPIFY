using System.Threading.Tasks;
using domain.Entities;
using Domain.Exceptions;

public class SysAdminService : ISysAdminService
{
    private readonly ISysAdminRepository _sysAdminRepository;
    public SysAdminService(ISysAdminRepository sysAdminRepository)
    {
        _sysAdminRepository = sysAdminRepository;
    }

    public async Task<IEnumerable<SysAdminDto>> GetAll()
    {
        var list = await _sysAdminRepository.GetAllAsync();
        return SysAdminDto.CreateList(list);
    }

    public async Task<SysAdminDto> GetById(int id)
    {
        var sysAdmin = await _sysAdminRepository.GetByIdAsync(id);
        if (sysAdmin == null)
        {
            throw new NotFoundException("SysAdmin no encontrado.");
        }
        return SysAdminDto.Create(sysAdmin);
    }

    public async Task<SysAdmin>Create(SysAdminCreateRequest request)
    {
        var newSysAdmin = new SysAdmin(request.Name, request.Surname, request.Email, request.Password, request.NumberPhone, request.DocumentType, request.Dni);
        await _sysAdminRepository.CreateAsync(newSysAdmin);
        return newSysAdmin;
    }

    public async Task<SysAdmin> Update(int id, SysAdminUpdateRequest request)
    {
       
        var sysAdmin = await _sysAdminRepository.GetByIdAsync(id); 

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

        await _sysAdminRepository.UpdateAsync(sysAdmin); 

        return sysAdmin; 
    }
    
    public async Task Delete(int id)
    {
      var sysAdmin = await _sysAdminRepository.GetByIdAsync(id);
        if (sysAdmin == null)
        {

            throw new Exception("Admin no encontrado");
        }
        await _sysAdminRepository.DeleteAsync(sysAdmin);
    }
}