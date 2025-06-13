using Application.Models;
using domain.Entities;
using domain.Interfaces;
using Domain.Exceptions;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
            var list = await _clientRepository.GetAllAsync();
            return ClientDTO.CreateList(list);
        }
        public async Task<ClientDTO?> GetById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                throw new NotFoundException("Cliente no encontrado.");
            }
            return ClientDTO.Create(client);
        }
        public async Task<Client?> Create(ClientCreateRequest dto)
        {
            var newClient = new Client(dto.Name, dto.Surname, dto.Email, dto.Password, dto.NumberPhone, dto.DocumentType, dto.Dni);
            await _clientRepository.CreateAsync(newClient);
            return newClient;
        }
        public async Task<Client> Update(int id, ClientUpdateRequest request)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                throw new NotFoundException("Cliente no encontrado.");
            }

            client.Name = request.Name;
            client.Surname = request.Surname;
            client.Email = request.Email;
            client.Password = request.Password;
            client.NumberPhone = request.NumberPhone;
            client.DocumentType = request.DocumentType;
            client.Dni = request.Dni;

            /*await*/
           await _clientRepository.UpdateAsync(client);

            return client/*client cuando se haga asincronica*/;
        }
        public async Task Delete(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                throw new NotFoundException("Cliente no encontrado.");
            }
            /*await*/
           await _clientRepository.DeleteAsync(client);   
        }
    }
}