using domain.Entities;
using domain.Interfaces;

public interface IAdressesRepository : IBaseRepository<Addresses>
{
    List<Addresses> GetAll();
    Addresses GetById(int id);
}