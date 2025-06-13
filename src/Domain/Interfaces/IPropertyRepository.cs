using domain.Entities;
using domain.Interfaces;

public interface IPropertyRepository : IBaseRepository<Property>
{
    Task<List<Property>> GetAllAsync();
    Task<Property> GetByIdAsync(int id);
}