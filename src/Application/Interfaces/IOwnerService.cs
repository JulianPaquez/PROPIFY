using domain.Entities;

public interface IOwnerService
{
    List<OwnerDTO> GetAll();
    OwnerDTO GetById(int id);
    Owner Create(OwnerCreateRquest request);
    void Update(int id, OwnerUpdateRequest request);
    void Delete(int id);
}