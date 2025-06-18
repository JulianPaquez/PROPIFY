using Application.Models.Request;
using domain.Entities;

namespace application.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client?> GetById(int id);
        Task<Client?> Create(AddClientRequest dto);
        Task Update(int id, AddClientRequest request);
        Task Delete(Client client);
    }
}