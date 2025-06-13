using Application.Models;
using domain.Entities;

public interface IClientService
{
    Task<IEnumerable<ClientDTO>> GetAll();
    Task<ClientDTO?> GetById(int id);
    Task<Client?> Create(ClientCreateRequest dto);
    Task<Client> Update(int id, ClientUpdateRequest request);
    Task Delete(int id);
}