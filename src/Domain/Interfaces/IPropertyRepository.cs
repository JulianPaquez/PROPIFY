using domain.Entities;
using domain.Interfaces;

public interface IPropertyRepository : IBaseRepository<Property>
{
    List<Property> GetAll();
    Property GetById(int id);
}