using domain.Entities;

public interface IOwnerService
{
    Task<Owner> Create(OwnerCreateRquest request);
    Task<Owner> Update(int id, OwnerUpdateRequest request);
    Task<OwnerDTO> GetById(int id);
    Task<IEnumerable<OwnerDTO>> GetAll();
    Task Delete(int id);
}