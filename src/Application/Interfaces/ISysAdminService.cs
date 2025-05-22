using domain.Entities;

public interface ISysAdminService
{
    List<SysAdminDto> GetAll();
    SysAdminDto GetById(int id);
    SysAdmin Create(SysAdminCreateRequest request);
    void Update(int id, SysAdminUpdateRequest request);
    void Delete(int id);
}