using domain.Entities;

public interface ISysAdminService
{
    Task<IEnumerable<SysAdminDto>> GetAll();
    Task<SysAdminDto> GetById(int id);
   Task<SysAdmin>Create(SysAdminCreateRequest request);
    Task<SysAdmin> Update(int id, SysAdminUpdateRequest request);
    Task Delete(int id);
}