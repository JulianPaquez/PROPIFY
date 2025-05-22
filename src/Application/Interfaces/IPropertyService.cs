public interface IPropertyService
{
    List<PropertyDto> GetAll();
    PropertyDto GetById(int id);
    void Create(PropertyCreateRequest request);
    void Update(int id, PropertyUpdateRequest request);
    void Delete(int id);
}