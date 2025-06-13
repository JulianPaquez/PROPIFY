using domain.Entities;

public interface IPropertyService
{
    Task<IEnumerable<PropertyDto>> GetAll();
    Task<PropertyDto> GetById(int id) ;
    Task<Property> Create(PropertyCreateRequest request);
    Task<Property> Update(int id, PropertyUpdateRequest request);
    Task Delete(int id);
}